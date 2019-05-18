using UnityEditor;
using System.Linq;
using System;

static class BuildCommand
{
    static string GetArgument(string name)
    {
        string[] args = Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i].Contains(name))
            {
                return args[i + 1];
            }
        }

        return null;
    }

    static string[] GetEnabledScenes()
    {
        return (
            from scene in EditorBuildSettings.scenes
            where scene.enabled
            where !string.IsNullOrEmpty(scene.path)
            select scene.path
        ).ToArray();
    }

    static BuildTarget GetBuildTarget()
    {
        string buildTargetName = GetArgument("customBuildTarget");
        Console.WriteLine(":: Received customBuildTarget " + buildTargetName);

        return ToEnum(buildTargetName, BuildTarget.NoTarget);
    }

    static string GetBuildPath()
    {
        string buildPath = GetArgument("customBuildPath");
        Console.WriteLine(":: Received customBuildPath " + buildPath);
        if (buildPath == "")
        {
            throw new Exception("customBuildPath argument is missing");
        }
        return buildPath;
    }

    static string GetBuildName()
    {
        string buildName = GetArgument("customBuildName");
        Console.WriteLine(":: Received customBuildName " + buildName);

        if (buildName == "")
        {
            throw new Exception("customBuildName argument is missing");
        }

        return buildName;
    }

    static string GetFixedBuildPath(BuildTarget buildTarget, string buildPath, string buildName)
    {
        if (buildTarget.ToString().ToLower().Contains("windows"))
        {
            buildName = buildName + ".exe";
        }
        else if (buildTarget.ToString().ToLower().Contains("webgl"))
        {
            // webgl produces a folder with index.html inside, there is no executable name for this buildTarget
            buildName = "";
        }
        return buildPath + buildName;
    }

    static BuildOptions GetBuildOptions()
    {
        return BuildOptions.None;
    }

    static TEnum ToEnum<TEnum>(this string strEnumValue, TEnum defaultValue)
    {
        if (!Enum.IsDefined(typeof(TEnum), strEnumValue))
        {
            return defaultValue;
        }

        return (TEnum)Enum.Parse(typeof(TEnum), strEnumValue);
    }

    static string getEnv(string key, bool secret = false, bool verbose = true)
    {
        var env_var = Environment.GetEnvironmentVariable(key);

        if (!verbose)
        {
            return env_var;
        }

        if (env_var == null)
        {
            Console.WriteLine(":: env['" + key + "'] is null");
        }
        else
        {
            if (secret)
            {
                Console.WriteLine(":: env['" + key + "'] set");
            }
            else
            {
                Console.WriteLine(":: env['" + key + "'] set to '" + env_var + "'");
            }
        }

        return env_var;
    }

    static void PerformBuild()
    {
        var buildTarget = GetBuildTarget();
        var buildPath = GetBuildPath();
        var buildName = GetBuildName();
        var fixedBuildPath = GetFixedBuildPath(buildTarget, buildPath, buildName);

        Console.WriteLine(":: Performing build");
        BuildPipeline.BuildPlayer(GetEnabledScenes(), fixedBuildPath, buildTarget, GetBuildOptions());
        Console.WriteLine(":: Done with build");
    }
}
