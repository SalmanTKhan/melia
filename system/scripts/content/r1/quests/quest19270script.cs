//--- Melia Script -----------------------------------------------------------
// Release the Pasagos Cliff seal{nl} in Ramstis Ridge
//--- Description -----------------------------------------------------------
// Quest to Release the seal at Pasagos Cliff..
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

[QuestScript(19270)]
public class Quest19270Script : QuestScript
{
	protected override void Load()
	{
		SetId(19270);
		SetName("Release the Pasagos Cliff seal{nl} in Ramstis Ridge");
		SetDescription("Release the seal at Pasagos Cliff.");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "ROKAS25_REXIPHER1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(61));

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("ROKAS25_SWITCH1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_SWITCH1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		character.Tracks.Start(this.TrackData);

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		ZoneServer.Instance.World.FindNPC("ROKAS25_SWITCH1")?.PlayEffectLocal(character.Connection, "F_explosion004_yellow", 1f, "BOT");
		// Func/SCR_ROKAS25_REXIPHER4_SEAL1_TEXT_PLAY;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

