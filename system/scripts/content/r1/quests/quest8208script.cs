//--- Melia Script -----------------------------------------------------------
// Wrong Salvation (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Sad Owl Sculpture.
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

[QuestScript(8208)]
public class Quest8208Script : QuestScript
{
	protected override void Load()
	{
		SetId(8208);
		SetName("Wrong Salvation (1)");
		SetDescription("Talk to Sad Owl Sculpture");

		AddPrerequisite(new LevelPrerequisite(109));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_SECTOR_04", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN72_SECTOR_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("KATYN72_MQ_09_01", "KATYN72_MQ_09", "I will persuade the souls and send them here", "About the missing souls", "Decline"))
		{
			case 1:
				dialog.UnHideNPC("KATYN72_GHOST");
				character.AddonMessage(AddonMessage.NOTICE_Dm_Exclaimation, "Persuade the spirit that is heading towards Amolallul Hill{nl}and guide it to the Sad Owl Sculpture!");
				character.Quests.Start(this.QuestId);
				break;
			case 2:
				await dialog.Msg("KATYN72_MQ_09_add");
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("KATYN72_MQ_09_03");
		dialog.HideNPC("KATYN72_GHOST");
		dialog.HideNPC("KATYN72_CALL");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN72_MQ_10");
	}
}

