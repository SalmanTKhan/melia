//--- Melia Script -----------------------------------------------------------
// No Freedom (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Rimos' Spirit.
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

[QuestScript(30022)]
public class Quest30022Script : QuestScript
{
	protected override void Load()
	{
		SetId(30022);
		SetName("No Freedom (2)");
		SetDescription("Talk with the Rimos' Spirit");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "CATACOMB_38_1_SQ_06_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(194));
		AddPrerequisite(new CompletedPrerequisite("CATACOMB_38_1_SQ_05"));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6014));

		AddDialogHook("CATACOMB_38_1_NPC_03", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_1_NPC_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CATACOMB_38_1_SQ_06_select", "CATACOMB_38_1_SQ_06", "Tell him that you would burn him with the purification powders", "Tell him to resolve his fault himself"))
		{
			case 1:
				await dialog.Msg("CATACOMB_38_1_SQ_06_prog_start");
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

		await dialog.Msg("CATACOMB_38_1_SQ_06_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_1_SQ_07");
	}
}

