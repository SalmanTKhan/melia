//--- Melia Script ----------------------------------------------------------
// Beauty Shop
//--- Description -----------------------------------------------------------
// NPCs found in and around Beauty Shop.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class CBarberDressNpcScript : GeneralScript
{
	public override void Load()
	{
		// Barber Shop
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Barber Shop", "c_barber_dress", 119.494, -2.628387, 1199.081, 90, "BEAUTY_HAIRSHOP_MOVE", "BEAUTY_HAIRSHOP_MOVE", "");
		
		// Boutique
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Boutique", "c_barber_dress", -6.559355, 54.28683, 111.2336, 270, "BEAUTY_BOUTIQUE_MOVE", "BEAUTY_BOUTIQUE_MOVE", "");
		
		// Klaipeda
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Klaipeda", "c_barber_dress", -5.580346, 4.718108, -111.731, 0, "BEAUTY_OUT_MOVE", "BEAUTY_OUT_MOVE", "");
		
		// [Hair Stylist]{nl}Anabell Swyn
		//-------------------------------------------------------------------------
		AddNpc(4, 161004, "[Hair Stylist]{nl}Anabell Swyn", "c_barber_dress", -15.95927, 4.718109, -55.1233, 90, "BEAUTY_SHOP_HAIR_F", "", "");
		
		// [Hair Stylist]{nl}Henry Swyn
		//-------------------------------------------------------------------------
		AddNpc(5, 161005, "[Hair Stylist]{nl}Henry Swyn", "c_barber_dress", -6.081351, 4.718109, 41.64191, 90, "BEAUTY_SHOP_HAIR_M", "", "");
		
		// [Fashion Designer]{nl}Kastytis
		//-------------------------------------------------------------------------
		AddNpc(6, 161003, "[Fashion Designer]{nl}Kastytis", "c_barber_dress", 23.59928, 6.875391, 1063.969, 90, "BEAUTY_SHOP_FASHION", "", "");
		AddNpc(7, 150020, " ", "c_barber_dress", -3.16, 6.88, 1105.25, -29, "", "", "");
		
		// Goddess' Blessing
		//-------------------------------------------------------------------------
		AddNpc(8, 160121, "Goddess' Blessing", "c_barber_dress", 21.01138, 6.875391, 1172.341, 200, "BLESSED_CUBE", "", "");
	}
}
