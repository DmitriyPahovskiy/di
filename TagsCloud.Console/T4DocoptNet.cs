





















using System.Collections;
using System.Collections.Generic;
using DocoptNet;

namespace TagsCloud.Console
{

    // Generated class for Main.usage.txt
	public class MainArgs
	{
		public const string USAGE = @"Example usage for T4 Docopt.NET

Usage:
  TagsCloud.Console.exe [--width=<wd>] [--height=<ht>] [--fontfamily=<ff>] [--fontsize=<fs>] [--spiralfactor=<sf>] [--spiralpower=<sp>] [--inputfile=<if>] [--outputfile=<of>]

Options:
 --width=<wd>		clouds width [default:800]
 --height=<ht>		clouds height [default:600]
 --fontfamily=<ff>  font family [default:Arial]
 --fontsize=<fs>	font size [default:16]
 --spiralfactor=<sf> archimedian spiral factor step [default:0.1]
 --spiralpower=<sp> archimedian spiral power [default:0.001]
 --inputfile=<if>   file with words [default:examples.txt]
 --outputfile=<of>  output file name

";
	    private readonly IDictionary<string, ValueObject> _args;
		public MainArgs(ICollection<string> argv, bool help = true,
                                                      object version = null, bool optionsFirst = false, bool exit = false)
		{
			_args = new Docopt().Apply(USAGE, argv, help, version, optionsFirst, exit);
		}

        public IDictionary<string, ValueObject> Args
        {
            get { return _args; }
        }

public string OptWidth { get { return null == _args["--width"] ? null : _args["--width"].ToString(); } }
		public string OptHeight { get { return null == _args["--height"] ? null : _args["--height"].ToString(); } }
		public string OptFontfamily { get { return null == _args["--fontfamily"] ? null : _args["--fontfamily"].ToString(); } }
		public string OptFontsize { get { return null == _args["--fontsize"] ? null : _args["--fontsize"].ToString(); } }
		public string OptSpiralfactor { get { return null == _args["--spiralfactor"] ? null : _args["--spiralfactor"].ToString(); } }
		public string OptSpiralpower { get { return null == _args["--spiralpower"] ? null : _args["--spiralpower"].ToString(); } }
		public string OptInputfile { get { return null == _args["--inputfile"] ? null : _args["--inputfile"].ToString(); } }
		public string OptOutputfile { get { return null == _args["--outputfile"] ? null : _args["--outputfile"].ToString(); } }
	
	}

	
}

