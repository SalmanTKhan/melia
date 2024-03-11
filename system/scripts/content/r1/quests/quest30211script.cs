//--- Melia Script -----------------------------------------------------------
// Pass the Tree Vines(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Researcher Veed.
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

[QuestScript(30211)]
public class Quest30211Script : QuestScript
{
	protected override void Load()
	{
		SetId(30211);
		SetName("Pass the Tree Vines(3)");
		SetDescription("Talk to Researcher Veed");

		AddPrerequisite(new LevelPrerequisite(223));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_3_SQ_6"));

		AddDialogHook("ORCHARD_34_3_SQ_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_OBJ_7", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_3_SQ_7_select", "ORCHARD_34_3_SQ_7", "Say that you will enhance the Antidote", "Say that you can endure"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_3_SQ_7_agree");
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

		ZoneServer.Instance.World.FindNPC("ORCHARD_34_3_SQ_OBJ_7")?.PlayEffectLocal(character.Connection, "F_spread_in010_green", 0.9f, "BOT");
		dialog.HideNPC("ORCHARD_34_3_SQ_OBJ_7");
		await Task.Delay(1000);
		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "You have removed the Tree Vines{nl}Now go to enhance the Antidote");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

