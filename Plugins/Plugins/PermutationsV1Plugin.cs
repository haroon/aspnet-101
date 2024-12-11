using mef.Common.Abstract;
using System.Composition;
using System.Numerics;

namespace mef.Plugins.Plugins;

[Export(typeof(AbstractPlugin))]
public class PermutationsPluginV1 : AbstractPlugin
{
    public override string GetName() => "permutations_v1";
    public override string GetDescription() => "Implementation of Heap's algorithm to get all possible permutations for a list of strings using recursion";
    public override int GetId() => 3;
    private List<string> permutations = new List<string>();

    public override object DoTheThing(Dictionary<string, object> parameters)
    {
        
        parameters.TryGetValue("method_version", out var numObj);
        int.TryParse(numObj?.ToString(), out var methodVersion);

        if (parameters.TryGetValue("perm_list", out var permListObj))
        {
            string[] permList = permListObj.ToString()!.Split(' ');
            return DoTheThing(methodVersion, permList);
        }

        throw new ArgumentException("Invalid parameters for PermutationV1Plugin.");
    }

    private string DoTheThing(int methodVersion, string[] permList)
    {
        if (methodVersion == 0)
        {
            Permutate1(0, permList);
        }
        else
        {
            Permutate2(permList.Length, permList);
        }
        return string.Join("\n", permutations);
    }

    private void Permutate1(int idx, string[] permList)
    {
        if (idx == permList.Length)
        {
            permutations.Add(string.Join("", permList));
        }
        else
        {
            for (int i = idx; i < permList.Length; ++i)
            {
                (permList[idx], permList[i]) = (permList[i], permList[idx]);
                Permutate1(idx + 1, permList);
                (permList[idx], permList[i]) = (permList[i], permList[idx]);
            }
        }
    }

    private void Permutate2(int idx, string[] permList)
    {
        if (idx == 1)
        {
            permutations.Add(string.Join("", permList));
        }
        else
        {
            Permutate2(idx - 1, permList);
            for (int i = 0; i < idx - 1; ++i)
            {
                if (idx % 2 == 0)
                {
                    (permList[idx - 1], permList[i]) = (permList[i], permList[idx - 1]);
                }
                else
                {
                    (permList[idx - 1], permList[0]) = (permList[0], permList[idx - 1]);
                }
                Permutate2(idx - 1, permList);
            }
        }
    }
}
