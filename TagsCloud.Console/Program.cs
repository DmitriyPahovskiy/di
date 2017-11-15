using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Globalization;
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
            var argv = new MainArgs(args);

            var culture = CultureInfo.InvariantCulture;
            var spiralFactorDelta = Single.Parse(argv.OptSpiralfactor, culture.NumberFormat);
            var spiralPower = Single.Parse(argv.OptSpiralpower, culture.NumberFormat);
            var basicFont = new Font(argv.OptFontfamily, Int32.Parse(argv.OptFontsize));
            var width = Int32.Parse(argv.OptWidth);
            var height = Int32.Parse(argv.OptHeight);
            var outputFile = argv.OptOutputfile ?? $"c:/temp/cloud_{DateTime.Now:yyMMdd_HHmmss}.png";
            var inputFileName = argv.OptInputfile ?? "examples.txt";



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

            builder.RegisterType<TagLoader>()
                .AsSelf();

            container = builder.Build();
            
            #endregion

            var reader = container.Resolve<TagLoader>();


            using (var painter = container.Resolve<Painter>())
            {
                Console.WriteLine("Reading file...");

                var tags = reader.ReadValidTagsWithWeights(inputFileName);
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
