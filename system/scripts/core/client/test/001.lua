-- Create system button to toggle buy-in shop creation window.
Melia.Ui.SysMenu.AddButton("BtnGamble", "sysmenu_wugushi", "Casual Gamble", "M_TOGGLE_GAMBLE()")

function M_TOGGLE_GAMBLE()

	local frame = ui.GetFrame("casualgamble")
	if frame:IsVisible() == 1 then
		CASUAL_GAMBLE_CLOSE();
	else
		CASUAL_GAMBLE_DO_OPEN();
	end
	
end

Melia.Override("IS_PERSONAL_HOUSING_PLACE", function()
	return true;
end)