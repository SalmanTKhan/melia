//--- Melia Script -----------------------------------------------------------
// Into the Grip (3)
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

[QuestScript(60129)]
public class Quest60129Script : QuestScript
{
	protected override void Load()
	{
		SetId(60129);
		SetName("Into the Grip (3)");
		SetDescription("Talk with Priest Irma");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON622_MQ_03"));

		AddObjective("kill0", "Kill 5 Wendigo Escapee(s)", new KillObjective(5, MonsterId.Sec_Escape_Wendigo));

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

		switch (await dialog.Select("PRISON622_MQ_04_01", "PRISON622_MQ_04", "I'll go there", "I'm going to rest for a while"))
		{
			case 1:
				await dialog.Msg("PRISON622_MQ_04_AG");
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

