//--- Melia Script -----------------------------------------------------------
// Mop Up the Forger (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vincent.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Shared.Game.Const;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;

[QuestScript(20160)]
public class Quest20160Script : QuestScript
{
	protected override void Load()
	{
		SetId(20160);
		SetName("Mop Up the Forger (3)");
		SetDescription("Talk to Vincent");

		AddPrerequisite(new LevelPrerequisite(61));
		AddPrerequisite(new CompletedPrerequisite("ROKAS25_SQ_02"));
		AddPrerequisite(new ItemPrerequisite("ROKAS25_SQ_03", -100));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_BINSENT", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_BINSENT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_SQ_04_select_01", "ROKAS25_SQ_04", "I will try", "Tell him to do it himself"))
		{
			case 1:
				dialog.HideNPC("ROKAS25_KEBIN");
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

		await dialog.Msg("ROKAS25_SQ_04_succ_01");
		ZoneServer.Instance.World.FindNPC("ROKAS25_BINSENT")?.PlayEffectLocal(character.Connection, "F_pc_warp_circle", 1f, "BOT");
		await Task.Delay(2000);
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

