using oai_poc_backend.Models;

namespace oai_poc_backend.Data_Transfer_Objects.From_server
{
    public class TemplateServerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FreeText { get; set; }
        public int? ProductId { get; set; }
        public List<SettingServerDto> Settings { get; set; } = new();
        public List<OptionServerDto> Options { get; set; } = new();

        public TemplateServerDto(TemplateModel template)
        {
            Id = template.Id;
            Name = template.Name;
            FreeText = template.FreeText;
            ProductId = template.ProductId;
            Settings = template.PromptSettings.Select(ps => new SettingServerDto(ps.Setting)).ToList();
            Options = template.PromptOptions.Select(po => new OptionServerDto(po.Option)).ToList();
        }
    }
}
