using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TagsCloudService.FileReaders;
using TagsCloudService.LayoutAlgorithms;
using TagsCloudService.Validators;

namespace TagsCloud.Console
{
using Console = System.Console;

    class Program
    {
        private static IContainer container;

        static void Main(string[] args)
        {
            var spiralFactorDelta = 0.1f;
            var spiralPower = 0.001f;
            var basicFont = new Font("Arial", 16);
            var width = 800;
            var height = 600;
            var outputFile = $"c:/temp/cloud_{DateTime.Now:yyMMdd_HHmmss}.png";
            var inputFileName = "examples.txt";

            #region Set up container

            var builder = new ContainerBuilder();

            builder.RegisterType<ColorProvider>()
                .As<ITagsColorProvider>()
                .UsingConstructor()
                .InstancePerDependency();

            builder.Register(c=>new ArchimedeanSpiralPositioner(spiralFactorDelta, spiralPower))
                .As<IPositioner>()
                .InstancePerDependency();

            // file readers:
            builder.RegisterType<TextFileReader>()
                .As<IReadFromFile>()
                .SingleInstance();
            
            // validators:
            builder.RegisterType<BoringWordsFilter>()
                .As<IValidateTag>()
                .SingleInstance();

            builder.Register(c => new Painter(width, height, outputFile))
                .AsSelf();

            builder.RegisterType<TagFileReader>()
                .AsSelf();

            container = builder.Build();
            
            #endregion

            var reader = container.Resolve<TagFileReader>();


            using (var painter = container.Resolve<Painter>())
            {
                Console.WriteLine("Reading file...");

                var tags = reader.ReadTagsWithWeights(inputFileName);
                var canvas = painter.Canvas;
                var layouter = new CircularCloudLayouter(canvas, basicFont, container.Resolve<IPositioner>(), container.Resolve<ITagsColorProvider>());

                Console.WriteLine("Tags loaded, painting...");

                foreach (var tag in tags)
                {
                    layouter.DrawNextTag(tag.Key, tag.Value);
                    Console.Write(".");
                }

                Console.WriteLine("done");
            }
        }
    }
}
