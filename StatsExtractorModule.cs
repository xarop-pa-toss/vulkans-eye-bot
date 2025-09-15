using NetCord;
using NetCord.Services;
using NetCord.Services.ApplicationCommands;

namespace vulkans_eye_bot;
//

[SlashCommand("stats", "Stats Extractor command")]
public class GuildCommandsModule : ApplicationCommandModule<ApplicationCommandContext>
{
    [SubSlashCommand("extract", "Get stats from post-dive stats screenshot")]
    public string Channels() => $"Channels: {Context.Guild!.Channels.Count}";    
    
    [SubSlashCommand("player", "Get stats for chosen player")]
    public string Channels4() => $"Channels: {Context.Guild!.Channels.Count}";    
    
    [SubSlashCommand("operation", "Get stats for chosen operation")]
    public string Channels3(User? user = null) => $"Username is {user.Username} and it is pretty noice";

    [SubSlashCommand("totals", "Get total stats from all players on all operations")]
    public string Channels2() => $"Channels: {Context.Guild!.Channels.Count}";

    [SubSlashCommand("stats_for_operation", "Get stats for chosen operation")]
    public class GuildNameModule : ApplicationCommandModule<ApplicationCommandContext>
    {
        [SubSlashCommand("get", "Get guild name")]
        public string GetName() => $"Name: {Context.Guild!.Name}";

        [RequireUserPermissions<ApplicationCommandContext>(Permissions.ManageGuild)]
        [RequireBotPermissions<ApplicationCommandContext>(Permissions.ManageGuild)]
        [SubSlashCommand("set", "Set guild name")]
        public async Task<string> SetNameAsync(string name)
        {
            var guild = Context.Guild!;
            await guild.ModifyAsync(g => g.Name = name);
            return $"Name: {guild.Name} -> {name}";
        }
    }
}