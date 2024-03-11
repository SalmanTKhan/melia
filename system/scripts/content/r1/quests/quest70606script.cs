//--- Melia Script -----------------------------------------------------------
// Gathering Divine Power
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70606)]
public class Quest70606Script : QuestScript
{
	protected override void Load()
	{
		SetId(70606);
		SetName("Gathering Divine Power");
		SetDescription("Talk to Monk Stella");
		SetTrack(QuestStatus.Possible, QuestStatus.Success, "ABBEY41_6_SQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(274));
		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ06"));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11234));

		AddDialogHook("ABBEY416_SQ_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY416_SQ_07_start", "ABBEY41_6_SQ07", "Say that you'll handle the monsters", "Ask if the Divine Power won't defeat the monsters"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}
}

