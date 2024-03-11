//--- Melia Script -----------------------------------------------------------
// Into the Grip (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Irma.
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

[QuestScript(60130)]
public class Quest60130Script : QuestScript
{
	protected override void Load()
	{
		SetId(60130);
		SetName("Into the Grip (4)");
		SetDescription("Talk with Priest Irma");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON622_MQ_04"));

		AddReward(new ExpReward(13430, 13430));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("PRISON621_IRMA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_IRMA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_MQ_05_01", "PRISON622_MQ_05", "I will try", "Tell me about what the priests prepared", "Please wait a while"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Go to the Bird Room and absorb the crystal's power", 8);
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("PRISON622_MQ_05_01_add");
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

