//--- Melia Script -----------------------------------------------------------
// Recruiting Mercenaries (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Toby.
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

[QuestScript(7073)]
public class Quest7073Script : QuestScript
{
	protected override void Load()
	{
		SetId(7073);
		SetName("Recruiting Mercenaries (1)");
		SetDescription("Talk to Mercenary Toby");

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 7 Desert Chupacabra(s)", new KillObjective(7, MonsterId.Chupacabra_Desert));
		AddObjective("kill1", "Kill 3 Zinute(s)", new KillObjective(3, MonsterId.Zinute));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_SUB1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_SUB1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS25_EX1_select1", "ROKAS25_EX1", "I am interested", "I'm not interested"))
		{
			case 1:
				await dialog.Msg("ROKAS25_EX1_select_startnpc1");
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

		await dialog.Msg("ROKAS25_EX1_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS25_EX2");
	}
}

