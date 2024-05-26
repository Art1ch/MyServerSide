СПИСОК КОММАНД:

1. /veh [veh_name] - создает указанный транспорт (по умолчанию - adder)
2. /gun [gun_name] [ammo] - создает указанное оружие и выдает указанные патроны (по умолчанию pistol - 500)
3. /healme - полностью лечит игрока, если его хп не больше 75
4. /createmarkerandcolshape - создает колшейп и марке на месте игрока
5. /kill - убивает игрока, вызвавшего команду
6. /test [name] [email] [age] [money] - передает данные на клиент, а после выводит соотв. атрибуты в чат
7. /servertest - создает ped на месте игрока
8. /clienttest - создает транспорт и ped неподалёку от игрока, после триггерится ивент на клиенте, заставляющий ехать ped на маркер на карте (маркер должен быть установлен до использования комманды)
9. /angry - создает ped рядом с игроком, после триггерится ивент на клиенте, ped становится враждебным и вооруженным RPG

СПИСОК СЕРВЕРНЫХ ОБРАБОТЧИКОВ:

1. OnPlayerSpawn - выдает игроку 100 брони и выводит в уведомления над мини-картой "You were spawned"
2. OnPlayerDeath - выводит в чат причину смерти, выводит в уведомления сообщение о смерти и ее причине
3. OnOnPlayerEnterVehicle - выводит в чат "You have entered the vehicle", меняет цвет машины на зеленый (55)
4. OnPlayerExitVehicle - выводит в чат "You have exited the vehicle", меняет цвет машины на желтый (42)
5. OnPlayerEnterColshape - выводит в чат player.Name + " has entered colshape"
6. OnPlayerENterColshape - выводит в чат player.Name + " has exited colshape"
7. OnRepairVeh - тригерится на клиенте с помощью клавиши F5, чинит машину игрока
8. OnDestroyVehicle - тригерится на клиенте с помощью клавиши F6, удаляет машину игрока

СПИСОК КЛИЕНТСКИХ ОБРАБОТЧИКОВ:

1. OnOutgoingDamageHandler - если урон наносится игроку, то выводит в чат "Don't fight with each other!"
2. OnEntityStreamInHandler - если в зоне стрима находится автомобиль, то выводит в чат "You see a car!"
3. OnEntityStreamOutHandler - если автомобиль перестаёт находиться в зоне стрима, то выводит в чат "Car has disappered!"
4. OnPlayerEnterVehicleHandler - выводит в чат HP двигателя и "CLIENT ENTER VEH"
5. OnPlayerDeathHandler - выводит в чат "You dead (CLIENT)"
6. OnPlayerCreateWaypointHandler - изменяет статическое поле MapMarkerCoords класса MapMarker на координаты метки игрока на карте
