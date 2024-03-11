//--- Melia Script -----------------------------------------------------------
// The Missing Bishop (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Inesa Hamondale.
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

[QuestScript(60086)]
public class Quest60086Script : QuestScript
{
	protected override void Load()
	{
		SetId(60086);
		SetName("The Missing Bishop (2)");
		SetDescription("Talk with Inesa Hamondale");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORSHA_MQ1_01"));

		AddReward(new ItemReward("Scroll_Warp_quest", 10));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_TOOL_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORSHA_MQ1_02_01", "ORSHA_MQ1_02", "Alright", "I don't think that'll be needed"))
		{
			case 1:
				await dialog.Msg("ORSHA_MQ1_02_01_01");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Scroll, "Worship the Statue of Goddess Ausrine in the Central Plaza!", 8);
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

