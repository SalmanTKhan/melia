//--- Melia Script -----------------------------------------------------------
// Hot-blooded Simon Shaw (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Simon Shaw.
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

[QuestScript(17023)]
public class Quest17023Script : QuestScript
{
	protected override void Load()
	{
		SetId(17023);
		SetName("Hot-blooded Simon Shaw (2)");
		SetDescription("Talk to Simon Shaw");

		AddPrerequisite(new LevelPrerequisite(126));
		AddPrerequisite(new CompletedPrerequisite("FTOWER45_SQ_01"));

		AddObjective("kill0", "Kill 8 Dimmer(s)", new KillObjective(8, MonsterId.Dimmer));
		AddObjective("kill1", "Kill 5 Black Shaman Doll(s)", new KillObjective(5, MonsterId.Tower_Of_Firepuppet_Black));
		AddObjective("kill2", "Kill 5 Black Drake(s)", new KillObjective(5, MonsterId.Fire_Dragon_Purple));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("FTOWER45_SQ_02_ST", "FTOWER45_SQ_02", "Don't worry", "I can only help so much"))
		{
			case 1:
				ZoneServer.Instance.World.FindNPC("FTOWER45_SQ_01")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 0.5f, "BOT");
				dialog.HideNPC("FTOWER45_SQ_01");
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

		dialog.UnHideNPC("FTOWER45_SQ_03");
		await dialog.Msg("FTOWER45_SQ_02_COMP");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FTOWER45_SQ_03");
	}
}

