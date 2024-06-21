using Dapper;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using MySqlConnector;
using RankSystem.PluginHelper;
using Serilog;

namespace RankSystem.CommandModules;

public class RankSlashCommandModule: ApplicationCommandModule
{
    /// <summary>
    /// Adds a channel to the blacklist.
    /// </summary>
    /// <param name="context">The interaction context.</param>
    /// <param name="targetUser">The user to check. If null, the executing user will be the target user.</param>
    /// <returns></returns>
    [SlashCommand( "Rank","Check the RankSystem Points of a user")]
    // ReSharper disable once UnusedMember.Global
    public async Task RankCommand(InteractionContext context, [Option("user","User to check")] DiscordUser? targetUser = null)
    {
        await context.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
        
        //If the Target User is null (wasn't specified in command) the executing user is the target user
        targetUser ??= context.User;

        //true if user is the target user
        var isUserTarget = targetUser.Id == context.User.Id;

        await context.EditResponseAsync(await UserRankDisplayHelper.BuildDisplayAsync(context.Guild, targetUser, isUserTarget));
    }
    
}