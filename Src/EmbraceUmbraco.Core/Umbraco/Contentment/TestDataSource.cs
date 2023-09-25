using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Community.Contentment.DataEditors;

namespace EmbraceUmbraco.Core.Umbraco.Contentment;

public class TestDataSource : IDataSourceValueConverter, IDataListSource
{
    public string Name => "Test DataSource";
    public string Description => "Test DataSource description";
    public string Icon => "icon-umb-media";
    public string Group => "Custom";
    
    public OverlaySize OverlaySize => OverlaySize.Small;

    public Dictionary<string, object> DefaultValues => new();
    public IEnumerable<ConfigurationField> Fields => Array.Empty<ConfigurationField>();
    
    public Type GetValueType(Dictionary<string, object> config)
    {
        return typeof(string);
    }

    public object ConvertValue(Type type, string value)
    {
        return value;
    }
    
    public IEnumerable<DataListItem> GetItems(Dictionary<string, object> config)
    {
        return new[]
        {
            new DataListItem
            {
                Name = "Test 1",
                Value = "test-1"
            },
            new DataListItem
            {
                Name = "Test 2",
                Value = "test-2"
            },
            new DataListItem
            {
                Name = "Test 3",
                Value = "test-3"
            }
        };
    }
}