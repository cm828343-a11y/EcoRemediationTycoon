# Eco Remediation Tycoon

An iOS environmental remediation management game inspired by RollerCoaster Tycoon.

## Concept
Players manage polluted sites across multiple levels. Each level focuses on different pollution types:
- Air pollution
- Water pollution
- Solid waste / landfills
- Oil spills
- Groundwater pollution
- Noise pollution

### Core Loop
1. Test the environment for contamination levels
2. Place remediation equipment within a budget
3. Run treatment systems to reduce pollution
4. Earn money as pollution is controlled
5. Unlock advanced treatment technologies
6. Progress to the next level / site

## Tech Stack
- **Engine**: Unity (C#)
- **Target**: iOS (App Store)
- **Monetization**: In-app purchases, optional ads

## Project Structure (Unity)
```
Assets/
  Scripts/
    Core/
    Pollution/
    Remediation/
    Economy/
    UI/
  Prefabs/
  Scenes/
  ScriptableObjects/
```

## Getting Started
1. Clone this repo
2. Open in Unity (2022 LTS or newer recommended)
3. Add the scripts from `Assets/Scripts/`
4. Build for iOS via Xcode

## Roadmap
- [ ] Core pollution simulation system
- [ ] Equipment placement system
- [ ] Economy & progression
- [ ] Level design for each pollution type
- [ ] Monetization (StoreKit / IAP)
- [ ] Polish & App Store submission

---
Built with Grok. Ready for Unity import.
