# TINF20C_ModellingWizard_Devices
Es soll eine Applikation entwickelt werden, die über eine einfach bedienbare GUI das Anlegen eines Devices und das Hinzufügen von Geräteschnittstellen (z.B. physikalische  Ports) und Datei-Attachements ermöglicht. Das Anlegen eines Devices kann manuell erfolgen, aber auch durch Einlesen bestehender Gerätebeschreibungsdateien unter Zuhilfename des DD2AML-Converters. Als Ausgabe soll ein AutomationML-Package erzeugt werden, dass den Regeln für AML-Komponentenmodelle (AML-DDs) entspricht. Dabei kann ein Vorgängerprojekt als Grundlageverwendet  werden. Primär solleine Standalone-Applikation für Windows mit verbesserter GUI entwickelt und eine Unterstützung für die Modellierung von Sensoren nach IEC60947-5 angeboten werden.

# Members
- [Florian Kellermann](https://github.com/NormalParameter)
- [Florian Kaiser](https://github.com/H4CK3R-01)
- [Malte Horst](https://github.com/mhorst00)
- [Lukas Ernst](https://github.com/Cyber-Luke)
- [Linus Eickhoff](https://github.com/Rripped)

# Tasks
- Entwurf einer GUI und eines zugehörigen Usability-Konzepts
- Unterstützung von CAEX 2.15 und CAEX 3.0 als Ausgabeformat (konfigurierbar)
- Eingabefelder für alle Parameter, die nach den Minimalregeln für AML-DDs gefordert werden.
- Generische Funktionalität zur Anlage von Schnittstellen (elektrisch, mechanisch, hydraulisch etc.). Automatische Bereitstellung von technologiebezogenen Default-Icons und Gerätebildern.
- Wizardunterstützung für die Sensormodellierung.
- Bei elektrischen Schnittstellen soll die Verwendung der AML-Schnittstellenbibliothek ausgewählt werden können.
- Eine ausführliche Benutzerdokumentation ist zu erstellen.

# Links
- https://github.com/DekaAthlos/TINF19C-ModellingWizard/tree/master
- https://github.com/WAntonia/TINF18C_Team_3_DD2AML-Converter
- https://www.automationml.org/download-archive/
- http://wwwlehre.dhbw-stuttgart.de/~rentschler/Publications/ETFA_2021_SensorModelling_with_AML.pdf
- http://wwwlehre.dhbw-stuttgart.de/~rentschler/Publications/ETFA_2021_SensorModelling_Presentation.pdf
- http://wwwlehre.dhbw-stuttgart.de/~rentschler/Publications/IndustrialSensorLibrary_CAEX3_v1_1_0.aml
