//--- Melia Script -----------------------------------------------------------
// Royal Mausoleum's Secret Location
//--- Description -----------------------------------------------------------
// Quest to Go to Royal Mausoleum's secret location.
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

[QuestScript(20176)]
public class Quest20176Script : QuestScript
{
	protected override void Load()
	{
		SetId(20176);
		SetName("Royal Mausoleum's Secret Location");
		SetDescription("Go to Royal Mausoleum's secret location");

		AddPrerequisite(new LevelPrerequisite(69));
		AddPrerequisite(new CompletedPrerequisite("ROKAS28_QM1"));

		AddReward(new ItemReward("misc_gemExpStone01", 1));

		AddDialogHook("ROKAS28_SECRET_PORTAL", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHA32_DEVICE_1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("NPCAin/ZACHA32_DEVICE_1_2/ON/1");
		ZoneServer.Instance.World.FindNPC("ZACHA32_DEVICE_1_2")?.PlayEffectLocal(character.Connection, "F_light003_green", 3f, "MID");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

