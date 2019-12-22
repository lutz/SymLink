namespace SymLinkDir
{
    class SymLinkDir
    {
        static void Main(string[] args)
        {
            if (TryParse(args, out ParseResult parseResult))
            {
                if (mklink.Exists(parseResult.Link))
                    mklink.Delete(parseResult.Link);

                mklink.Create(parseResult.Link, parseResult.Target, false);

            }
        }

        static bool TryParse(string[] args, out ParseResult parseResult)
        {
            parseResult = null;

            if (args.Length != 2) return false;
            if (!System.IO.Directory.Exists(args[1])) return false;

            parseResult = new ParseResult { Link = args[0], Target = args[1] };
            return true;
        }
    }

    class ParseResult
    {
        public string Link { get; set; }

        public string Target { get; set; }
    }
}
