//--- Melia Script -----------------------------------------------------------
// Release Goddess Saule (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Saule.
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

[QuestScript(18006)]
public class Quest18006Script : QuestScript
{
	protected override void Load()
	{
		SetId(18006);
		SetName("Release Goddess Saule (3)");
		SetDescription("Talk to Goddess Saule");

		AddPrerequisite(new LevelPrerequisite(55));
		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ05"));

		AddObjective("kill0", "Kill 15 Beeteros(s) or Mantiwood(s) or Carcashu(s) or Tini Magician(s)", new KillObjective(15, 57024, 57025, 57029, 57606));

		AddReward(new ExpReward(67536, 67536));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("HUEVILLAGE_58_4_MQ06_select", "HUEVILLAGE_58_4_MQ06", "I'll defeat the monsters nearby", "I'm sorry, but I don't think I can"))
		{
			case 1:
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

		await dialog.Msg("HUEVILLAGE_58_4_MQ06_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

