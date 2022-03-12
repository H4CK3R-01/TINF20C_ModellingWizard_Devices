# SOURCE

## Structure
Der `SOURCE` Ordner enthält zwei unter Ordner: `Application` und `Plugin`.
Der Ordner `Plugin` enthält den Source Code des Plugins aus dem Repository [TINF19C-ModellingWizard](https://github.com/DekaAthlos/TINF19C-ModellingWizard).
Der Ordner `Application` entählt die eigentliche Windows-Forms Anwendung, die die Klasse `DeviceDescription` aus dem Ordner `Plugin` nutzt.

## Development
Um Änderungen an der Anwendung vorzunehmen muss zuerst Visual Studio 2019 installiert werden.
In Visual Studio 2019 muss dann die Datei `Application.sln` aus dem `Application`-Ordner geöffnet werden.

In der Projektmappen-Ansicht ist dann zum einen die Applikation als auch das Plugin (ModellingWizard) zu sehen.

Um die Anwendung kompilieren zu können, muss über den NuGet-Paketmanager eventuel noch das `AML.Engine`-Paket in der Version 1.5.8 installiert werden.
