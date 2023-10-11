//--- Melia Script -----------------------------------------------------------
// Negotiation (1)
//--- Description -----------------------------------------------------------
// Quest to Trace Rexipher.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(9000)]
public class Quest9000Script : QuestScript
{
	protected override void Load()
	{
		SetId(9000);
		SetName("Negotiation (1)");
		SetDescription("Trace Rexipher");

		AddPrerequisite(new LevelPrerequisite(78));
		AddPrerequisite(new CompletedPrerequisite("ROKAS30_MQ8"));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_PACT_END", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_REXITHER2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS31_PACT_END_select1", "ROKAS31_PACT_END", "Where is she?!", "No"))
		{
			case 1:
				await dialog.Msg("ROKAS31_PACT_END_SUCC01");
				dialog.HideNPC("ROKAS31_PACT_END");
				await dialog.Msg("FadeOutIN/2000");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("ROKAS31_PACT_END_COMP");
		await dialog.Msg("FadeOutIN/1000");
		ZoneServer.Instance.World.FindNPC("ROKAS31_PACT_END")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
		dialog.HideNPC("ROKAS31_PACT_END");
		dialog.UnHideNPC("ROKAS31_REXITHER2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS31_REXITHER2");
	}
}

