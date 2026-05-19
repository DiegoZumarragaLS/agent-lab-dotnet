namespace SocOps.Tests;

internal static class SourceFileHelper
{
    internal static string ReadRelativeSource(string relativePath)
    {
        var root = FindRepositoryRoot();
        var fullPath = Path.Combine(root, relativePath.Replace('/', Path.DirectorySeparatorChar));
        return File.ReadAllText(fullPath);
    }

    private static string FindRepositoryRoot()
    {
        var current = new DirectoryInfo(AppContext.BaseDirectory);

        while (current != null)
        {
            var solutionPath = Path.Combine(current.FullName, "vscode-agent-lab-soc-ops-csharp.sln");
            var appProjectPath = Path.Combine(current.FullName, "SocOps");

            if (File.Exists(solutionPath) && Directory.Exists(appProjectPath))
            {
                return current.FullName;
            }

            current = current.Parent;
        }

        throw new InvalidOperationException("Unable to locate repository root.");
    }
}
