//--- Melia Script -----------------------------------------------------------
// Six Crystals
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30172)]
public class Quest30172Script : QuestScript
{
	protected override void Load()
	{
		SetId(30172);
		SetName("Six Crystals");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_8"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("PRISON_80_MQ_9_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 108650));

		AddDialogHook("PRISON_80_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_OBJ_5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_80_MQ_9_select", "PRISON_80_MQ_9", "Say that you should leave at once", "Say that you need to rest now"))
		{
			case 1:
				await dialog.Msg("PRISON_80_MQ_9_agree");
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

		await dialog.Msg("NPCAin/PRISON_80_OBJ_5/OPEN/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

