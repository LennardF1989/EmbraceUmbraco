using Examine;
using Examine.Lucene.Providers;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Infrastructure.Examine;

namespace EmbraceUmbraco.Core.Umbraco.Components;

public class ExamineComponent : IComponent
{
    private readonly IExamineManager _examineManager;

    public ExamineComponent(IExamineManager examineManager)
    {
        _examineManager = examineManager;
    }
    
    public void Initialize()
    {
        if (
            _examineManager.TryGetIndex(
                Constants.UmbracoIndexes.InternalIndexName, 
                out var internalIndex
            ) &&
            internalIndex is LuceneIndex internalUmbracoContentIndex
        )
        {
            internalUmbracoContentIndex.TransformingIndexValues += IndexProviderTransformingIndexValues;
        }
    }

    public void Terminate()
    {
        //Do nothing
    }

    private void IndexProviderTransformingIndexValues(object sender, IndexingItemEventArgs e)
    {
        if (e.ValueSet.Category != IndexTypes.Content)
        {
            return;
        }
        
        var values = e
            .ValueSet
            .Values
            .ToDictionary(
                x => x.Key,
                x => (IEnumerable<object>)x.Value.ToList()
            );

        values["somekey"] = new List<object> { "somevalue" };
        
        e.SetValues(values);
    }
}