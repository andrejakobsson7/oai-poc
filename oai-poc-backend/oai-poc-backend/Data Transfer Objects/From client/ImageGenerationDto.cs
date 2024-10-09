using oai_poc_backend.Models;

namespace oai_poc_backend.Data_Transfer_Objects
{
    public class ImageGenerationDto
    {
        public int Id { get; set; }

        public string Prompt { get; set; } = null!;

        public List<CategoryValueDto> Settings { get; set; } = new();

        public ImageGenerationDto(PromptModel prompt, PromptDto promptDto)
        {
            Id = prompt.Id;
            Prompt = prompt.FreeText;
            Prompt = CreatePromptFromFreeTextAndSelectedOptions(promptDto.Options);
            Settings = CreateSettings(promptDto.Settings);
        }

        //Put together the free text and selected options to a string.
        private string CreatePromptFromFreeTextAndSelectedOptions(List<OptionDto> options)
        {
            string promptWithOptions = Prompt.ToString();
            options.ForEach(option =>
            {
                //Add comma separator
                promptWithOptions += ", ";
                //Add the detailed description of the selected option to the string.
                promptWithOptions += option.DetailedDescription;
            });
            return promptWithOptions;
        }

        //Create a list for settings
        private List<CategoryValueDto> CreateSettings(List<SettingDto> settings)
        {
            List<CategoryValueDto> categoryValues = new();
            settings.ForEach(setting =>
            {
                CategoryValueDto categoryValue = new(setting.CategoryName, setting.Name);
                categoryValues.Add(categoryValue);
            });
            return categoryValues;
        }

    }
}
