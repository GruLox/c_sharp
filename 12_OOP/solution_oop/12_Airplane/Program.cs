BomberJet bomberJet = new BomberJet("B-2 Spirit", "Bomber", 630);
FighterJet fighterJet = new FighterJet("F-22 Raptor", "Fighter", 1500);

for (int i = 0; i < 10; i++)
{
    bomberJet.Attack();
    fighterJet.Attack();
}