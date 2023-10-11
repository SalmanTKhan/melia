//--- Melia Script -----------------------------------------------------------
// Deal with the stragglers in the Solitary Cells
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30171)]
public class Quest30171Script : QuestScript
{
	protected override void Load()
	{
		SetId(30171);
		SetName("Deal with the stragglers in the Solitary Cells");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_7"));

		AddObjective("kill0", "Kill 20 Blue Guardian Spider(s) or Red Socket Mage(s) or Red Darkness Maiden(s)", new KillObjective(20, 57989, 57930, 57940));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_80_MQ_8_select", "PRISON_80_MQ_8", "Say that the you are starting to deal with the stragglers", "State that you are tired and need to rest"))
		{
			case 1:
				await dialog.Msg("PRISON_80_MQ_8_agree");
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

		await dialog.Msg("PRISON_80_MQ_8_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

