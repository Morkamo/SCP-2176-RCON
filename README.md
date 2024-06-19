**Добавлят на ваш сервер новый вариант SCP-2176**
Данный "Custom Item" спопособен накладывать указанные эффекты на игроков в зоне его влияния


*При взрыве в пределах комплекса и в карманном измерении зоной влияния SCP-2176-RCON является вся комната!
В то время как на улице зоной влияния является невидимая зона N-радиуса вокруг SCP-2176-RCON*

**Базовый Config:**
```
SCP-2176-RCON:
  is_enabled: true
  debug: false
  # Накладываемые эффекты на игроков при взрыве SCP-2176-RCON (в пределах комнаты) {EffectType} = {Duration}
  effects:
    Flashed: 5
    Ensnared: 5
  # Радиус действия - используется при взрыве на поверхности (RoomType.Surface)
  radius: 10
  # Настройки предмета SCP-2176-RCON
  item:
    id: 1
    weight: 1
    name: 'SCP-2176-RCON'
    description: '<color=green><b>This SCP-2176-RCON</b></color>'
    spawn_properties:
      limit: 0
      dynamic_spawn_points: []
      static_spawn_points: []
      role_spawn_points: []
    type: SCP2176
    scale:
      x: 1
      y: 1
      z: 1
```
