//--- Melia Script -----------------------------------------------------------
// Ominous Red Crystal (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91139)]
public class Quest91139Script : QuestScript
{
	protected override void Load()
	{
		SetId(91139);
		SetName("Ominous Red Crystal (2)");
		SetDescription("Talk to Pajauta");
		SetTrack(QuestStatus.Success, QuestStatus.Success, "EP14_2_DCASTLE1_MQ_6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(470));
		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_5"));

		AddObjective("collect0", "Collect 10 Crystal Piece with Rune Craved(s)", new CollectItemObjective("EP14_2_DCASTLE1_MQ_6_ITEM1", 10));
		AddDrop("EP14_2_DCASTLE1_MQ_6_ITEM1", 7f, 59741, 59742, 59743);

		AddDialogHook("EP14_2_1_PAJAUTA1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_2_DCASTLE1_MQ_6_DLG1", "EP14_2_DCASTLE1_MQ_6", "Alright", "It's too dangerous to go alone."))
		{
			case 1:
				await dialog.Msg("FadeOutIN/2000");
				dialog.HideNPC("EP14_2_1_PAJAUTA1");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE1_MQ_7");
	}
}

