using Examine;
using Examine.Lucene;
using Microsoft.Extensions.Options;
using Umbraco.Cms.Core;

namespace EmbraceUmbraco.Core.Umbraco.Options;

public class ExamineIndexOptions : IConfigureNamedOptions<LuceneDirectoryIndexOptions>
{
    public void Configure(LuceneDirectoryIndexOptions options)
    {
        Configure(string.Empty, options);   
    }
    
    public void Configure(string name, LuceneDirectoryIndexOptions options)
    {
        switch (name)
        {
            case Constants.UmbracoIndexes.InternalIndexName:
                options.FieldDefinitions.TryAdd(
                    new FieldDefinition("somekey", FieldDefinitionTypes.Raw)
                );
                break;
        }
    }
}