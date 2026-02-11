using Aco228.AIGen.PoyoAI.Models;
using Aco228.AIGen.PoyoAI.Services;
using Aco228.Common.Attributes;

namespace Aco228.TextGen.Consoler;

public class Tests
{
    [InjectService] public IPoyoImageGen PoyoImageGen { get; set; }

    public async Task CheckAll(params string[] tasks)
    {
        foreach (var task in tasks)
        {
            var res = await PoyoImageGen.GetResponse(task);
            if (res.code != 200)
                continue;

            if (res.data?.files?.Any() == false)
                continue;

            foreach (var file in res.data.files)
                Console.WriteLine($"url: {file.file_url}");
        }
    }
    
    public async Task GenerateForAll(string prompt)
    {
        await Generate(PoyoModelType.Flux2Pro, prompt);
        await Generate(PoyoModelType.gpt4o, prompt);
        await Generate(PoyoModelType.GrokImage, prompt);
        await Generate(PoyoModelType.Seadream4_5, prompt);
        await Generate(PoyoModelType.ZImage, prompt);
    }

    public async Task Generate(PoyoModelType model, string prompt)
    {
        var task =  await PoyoImageGen.GenerateAndGetTaskId(model, prompt);
        Console.WriteLine($"{model.ToString()}:{task}");
    }
}