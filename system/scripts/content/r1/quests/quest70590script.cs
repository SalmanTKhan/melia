//--- Melia Script -----------------------------------------------------------
// The Wishes of the Deceased
//--- Description -----------------------------------------------------------
// Quest to Examine the Unnamed Monk's Tombstone.
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

[QuestScript(70590)]
public class Quest70590Script : QuestScript
{
	protected override void Load()
	{
		SetId(70590);
		SetName("The Wishes of the Deceased");
		SetDescription("Examine the Unnamed Monk's Tombstone");

		AddPrerequisite(new LevelPrerequisite(271));

		AddObjective("kill0", "Kill 18 Brown Nuka(s) or Red Elma(s)", new KillObjective(18, 57986, 57988));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 11111));

		AddDialogHook("PILGRIM415_SQ_11", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM415_SQ_11", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM415_SQ_11_start", "PILGRIM41_5_SQ11", "Swear that you will deal with the Demons in the surrounding area", "Keep on going"))
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

		await dialog.Msg("BalloonText/PILGRIM415_SQ_11_succ/3");
		ZoneServer.Instance.World.FindNPC("PILGRIM415_SQ_11")?.PlayEffectLocal(character.Connection, "F_spread_out033_ground_light", 1f, "BOT");
		ZoneServer.Instance.World.FindNPC("PILGRIM415_SQ_11")?.PlayEffectLocal(character.Connection, "F_light094_blue", 2f, "BOT");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

