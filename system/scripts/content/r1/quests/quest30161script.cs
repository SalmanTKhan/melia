//--- Melia Script -----------------------------------------------------------
// Storage Lamp(5)
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

[QuestScript(30161)]
public class Quest30161Script : QuestScript
{
	protected override void Load()
	{
		SetId(30161);
		SetName("Storage Lamp(5)");
		SetDescription("Talk to Zanas' Soul");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "PRISON_79_MQ_8_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(262));
		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_7"));

		AddObjective("kill0", "Kill 8 Blue Nuo(s) or Red Socket Archer(s) or Blue Terra Imp Mage(s)", new KillObjective(8, 57983, 57932, 57951));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("PRISON_79_MQ_8_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10742));

		AddDialogHook("PRISON_79_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_OBJ_8", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_79_MQ_8_select", "PRISON_79_MQ_8", "Say that you will retrieve the King's Red Jewel", "Ask for a moment before continuing"))
		{
			case 1:
				await dialog.Msg("PRISON_79_MQ_8_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("NPCAin/PRISON_79_OBJ_8/OPEN/1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

