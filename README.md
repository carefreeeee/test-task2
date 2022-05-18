# test-task2

Тестовое задание соискателя
на должность программист

Общие сведения.

	Требуется выполнить разработку приложения, выполняющего указанные ниже функции. Основная цель – демонстрация навыков:
- анализа поставленной задачи, поиска необходимой для решения информации, создания структур данных и алгоритмов обработки;
- применения объектно-ориентированного программирования для решения задачи;
- разработки типового интерфейса пользователя;
- разработки кода, ориентированного на повторное использование и понятного для последующего сопровождения другими разработчиками.

Постановка задачи.

Реализовать калькулятор теплофизического параметра «Температура начала замерзания грунта» в соответствии с нормативным документом СП 25.13330.2012, Приложение Б, п. Б.5 по формуле (Б.3).
Пользователь на форме должен ввести известные ему данные:
№	Параметр
1	Тип грунта:
Пески разных фракций
Супеси и пылеватые пески
Суглинок
Глины
Торф слаборазложившийся
Торф среднеразложившийся
2	Засоленность грунта: 
незасоленный
засоленный (морской тип)
засоленный (континентальный тип)
3	Степень засоленности Dsal
4	Льдистость Itot
5	Суммарная влажность Wtot
6	Влажность мерзлого грунта Wm
По команде пользователя исходные данные могут быть сохранены в файл в формате JSON или загружены на форму из ранее сохраненного файла JSON с использованием системных диалоговых окон выбора файла.

На основании введенных данных по команде пользователя должен быть выполнен расчет величины Tbf. При этом исходные данные и результат вычислений накапливаются в сводную таблицу на форме (этой же или другой – на усмотрение разработчика).
По команде пользователя все данные сводной таблицы экспортируются в файл в формате JSON. Используются системные диалоговые окна выбора файла.

На форме в правом верхнем углу тикают часы реального времени с форматом вывода: Часы:Минуты:Секунды (число месяц_прописью год).
Все команды пользователя выполняются через главное меню программы стандартного вида.

Требования к реализации.

Язык программирования – C#.
Среда разработки - Visual Studio 2017 и позднее.
Интерфейс пользователя – классический, с использованием стандартных компонентов Visual Studio. Реализация – Windows Forms или WPF(предпочтительно).
Базовая платформа - .NET Framework 4.7. Использование дополнительных компонентов, пакетов сверх средств платформы – минимальное, обоснованное.
В приложении четко разделяются интерфейс пользователя и логика. Логика вычислений оформляется отдельными классами в отдельных файлах, в виде, удобном для повторного использования в других приложениях.
Наличие общих комментариев по реализации - по своему усмотрению, в неочевидных местах - обязательно. Описание тегами ///<summary> для классов и из методов реализации логики - обязательно.
