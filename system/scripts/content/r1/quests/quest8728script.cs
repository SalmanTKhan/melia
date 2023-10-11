//--- Melia Script -----------------------------------------------------------
// Ruklys' Inheritance
//--- Description -----------------------------------------------------------
// Quest to Talk to Epigraphist Schmid.
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

[QuestScript(8728)]
public class Quest8728Script : QuestScript
{
	protected override void Load()
	{
		SetId(8728);
		SetName("Ruklys' Inheritance");
		SetDescription("Talk to Epigraphist Schmid");

		AddPrerequisite(new LevelPrerequisite(96));
		AddPrerequisite(new CompletedPrerequisite("REMAIN37_SQ06"));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_SMEADE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_SQ07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_SQ07_01", "REMAIN37_SQ07", "I'll restore it", "Wait for a while"))
		{
			case 1:
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

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "Acquired 1 Status Point from the artifacts of Ruklys!");
		await dialog.Msg("REMAIN37_MQ_MONUMENT4_BASIC01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

