# RU

Есть N прямых конвейерных секций расположенных друг за другом. В конце каждой секции стоит датчик наличия груза. Сигнал с датчика NC, то есть при отсутствии груза на входе будет TRUE. Управление приводом осуществляется по средствам дискретного выхода.
(в проекте должен быть заведен файл с массивами N входов и выходов)
При появлении груза на датчике секция должна включиться и передать груз на впереди стоящую секцию,после чего отключиться. Должен быть реализован механизм запуска и остановки системы.
Количество секций N указывается константой, изменение применяется при ReBuild'e системы.

# EN

There are N straight conveyor sections arranged one after another. At the end of each section there is a load sensor. The signal from the sensor is NC, i.e. when there is no load on the input will be TRUE. Control of the drive is carried out by means of discrete output.
(a file with arrays of N inputs and outputs should be created in the project).
When the load appears on the sensor, the section must switch on and transfer the load to the section ahead of it, and then switch off. A mechanism for starting and stopping the system must be implemented.
The number of sections N is specified as a constant, the change is applied during ReBuild of the system.