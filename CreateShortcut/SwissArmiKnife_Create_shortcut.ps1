$dest = "$home\Desktop\"
$TargetFolderPath = "$PSScriptRoot\..\bin\Debug\net8.0-windows\SwissArmyKnife.exe"

# $shortcut_path = Join-Path -Path $dest -ChildPath "DLC LAB.lnk"
# $wshShell = New-Object -ComObject WScript.Shell

# $shortcut = $wshShell.CreateShortcut($shortcut_path)
# $shortcut.save()

# Define the shortcut file path and name (must end in .lnk)
$ShortcutPath = Join-Path -Path $dest -ChildPath "SwissArmyKnife.lnk"


# Ensure the target folder exists before creating a shortcut
if (Test-Path -Path $TargetFolderPath) {
    # Create the WScript.Shell COM object
    $WshShell = New-Object -ComObject WScript.Shell

    # Create the shortcut object
    $Shortcut = $WshShell.CreateShortcut($ShortcutPath)

    # Set the target path of the shortcut
    $Shortcut.TargetPath = $TargetFolderPath

    # Optional: Set an icon location (e.g., a standard folder icon)
    # $Shortcut.IconLocation = "imageres.dll,3"

    # Save the shortcut file
    $Shortcut.Save()

    Write-Host "Shortcut created successfully at: $ShortcutPath"
} else {
    Write-Host "Error: Target folder not found at $TargetFolderPath"
}

