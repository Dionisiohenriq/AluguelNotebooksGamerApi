using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelNotebooksGamerApi.Entities
{
    public class ModelConfiguration : BaseClass
    {
        public ModelConfiguration() : base() { }

        public ModelConfiguration(string? screen, int ram, string? processor, string? keyboard, string? webCam, string? sound, string? graphics) : this()
        {
            Screen = screen;
            RAM = ram;
            Processor = processor;
            Keyboard = keyboard;
            WebCam = webCam;
            Sound = sound;
            Graphics = graphics;
        }

        public string? Screen { get; private set; }
        public int RAM { get; private set; }
        public string? Processor { get; private set; }
        public string? Keyboard { get; private set; }
        public string? WebCam { get; private set; }
        public string? Sound { get; private set; }
        public string? Graphics { get; private set; }

        public void Configure(EntityTypeBuilder<ModelConfiguration> builder)
        {
            builder.HasBaseType(typeof(BaseClass));
        }
    }
}
