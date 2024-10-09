namespace oai_poc_backend.Data_Transfer_Objects
{
    public class CategoryValueDto
    {
        public string CategoryName { get; set; } = null!;
        public string Value { get; set; } = null!;

        public CategoryValueDto(string categoryName, string value)
        {
            CategoryName = categoryName;
            Value = value;
        }
    }
}
