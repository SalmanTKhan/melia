//--- Melia Script -----------------------------------------------------------
// Into the Hands (5)
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

[QuestScript(60127)]
public class Quest60127Script : QuestScript
{
	protected override void Load()
	{
		SetId(60127);
		SetName("Into the Hands (5)");
		SetDescription("Talk with Priest Irma");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON622_MQ_05"));

		AddReward(new ExpReward(13430, 13430));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 2646));

		AddDialogHook("PRISON621_IRMA", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON622_MQ_02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON622_MQ_02_01", "PRISON622_MQ_02", "I will try", "That's a very dangerous idea"))
		{
			case 1:
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Defeat the monsters around the Cursed Idol in the Examination Room.", 8);
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

