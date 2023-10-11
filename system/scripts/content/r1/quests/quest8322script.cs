//--- Melia Script -----------------------------------------------------------
// Soul Hunter (4)
//--- Description -----------------------------------------------------------
// Quest to Conversation with gloomy owl image.
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

[QuestScript(8322)]
public class Quest8322Script : QuestScript
{
	protected override void Load()
	{
		SetId(8322);
		SetName("Soul Hunter (4)");
		SetDescription("Conversation with gloomy owl image");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "KATYN18_MQ_16_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_15"));

		AddObjective("collect0", "Collect 1 Gateway Key", new CollectItemObjective("KATYN18_MQ_16_ITEM", 1));
		AddDrop("KATYN18_MQ_16_ITEM", 10f, "Hallowventor");

		AddObjective("kill0", "Kill 1 Hallowventer", new KillObjective(1, MonsterId.Hallowventor));
		AddObjective("kill1", "Kill 4 Evil Spirit(s)", new KillObjective(4, MonsterId.Banshee_Purple));

		AddDialogHook("KATYN18_OWL_04", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN18_MQ_16_01", "KATYN18_MQ_16", "I'll get rid of the Hallowventer", "Cancel"))
		{
			case 1:
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

		if (character.Inventory.HasItem("KATYN18_MQ_16_ITEM", 1))
		{
			character.Inventory.RemoveItem("KATYN18_MQ_16_ITEM", 1);
			await dialog.Msg("KATYN18_MQ_16_03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_17");
	}
}

