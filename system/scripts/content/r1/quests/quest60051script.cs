//--- Melia Script -----------------------------------------------------------
// Elegant Demon Lord
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Agatas.
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

[QuestScript(60051)]
public class Quest60051Script : QuestScript
{
	protected override void Load()
	{
		SetId(60051);
		SetName("Elegant Demon Lord");
		SetDescription("Talk to Pilgrim Agatas");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 1760));
		AddReward(new ItemReward("Drug_SP2_Q", 15));

		AddDialogHook("PILGRIM312_AGATAS_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM312_SQ_01_01", "PILGRIM312_SQ_01", "Save the person first", "I can't help the demons"))
		{
			case 1:
				await dialog.Msg("FadeOutIN/1000");
				dialog.UnHideNPC("PILGRIM312_HAUBERK_01");
				ZoneServer.Instance.World.FindNPC("PILGRIM312_HAUBERK_01")?.PlayEffectLocal(character.Connection, "F_spread_out004_dark", 0.7f, "BOT");
				await Task.Delay(3000);
				// Func/PILGRIM312_SQ_01_01_ADD;
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


		return HookResult.Break;
	}
}

