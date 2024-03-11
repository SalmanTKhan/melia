//--- Melia Script -----------------------------------------------------------
// The Eternal Adventure (1)
//--- Description -----------------------------------------------------------
// Quest to Go to Camp of Varkis.
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

[QuestScript(1060)]
public class Quest1060Script : QuestScript
{
	protected override void Load()
	{
		SetId(1060);
		SetName("The Eternal Adventure (1)");
		SetDescription("Go to Camp of Varkis");

		AddPrerequisite(new LevelPrerequisite(73));
		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS2"));
		AddPrerequisite(new ItemPrerequisite("VACYS_note", -100));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1387));

		AddDialogHook("VACYS_SOUL", "BeforeStart", BeforeStart);
		AddDialogHook("VACYS_SOUL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ROKAS29_VACYS3_ST", "ROKAS29_VACYS3", "I will find it", "Leave"))
		{
			case 1:
				await dialog.Msg("ROKAS29_VACYS3_AC");
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "It's written that the next document is hidden on the way to Neck Cliff of Snake!");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

