using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_b : MonoBehaviour {
    public GameObject active_chacker; // текущий объект
    public Transform possible_move; // для создания квадратов, куда ходить
    public List<GameObject> empty_plases; // для хранения всех квадратов, куда можна ходить
    [HideInInspector]
    public bool is_checker_active; // проверка активна ли шашка, тоесть то, что игрок хочет ней ходить
    private List<GameObject> checker_white; // масив белых шашок
    private List<GameObject> checker_black; // масив черных шашок
    public bool is_damka;
    public Sprite damka_sprite;
    public List<GameObject> squares_who_need_destroy;
    void Start() {
        // заполнение переменных
        squares_who_need_destroy = new List<GameObject>();
        checker_white = new List<GameObject>();
        checker_black = new List<GameObject>();
        empty_plases = new List<GameObject>();
        is_checker_active = false;
        is_damka = false;
    }


    void OnMouseDown() // mouse click into checker
    {
        // ищет в скрипте StartGame.cs белые и черные шашки
        GameProcess target = (GameProcess)FindObjectOfType(typeof(GameProcess));
        checker_white = target.GetComponent<GameProcess>().Chechs_white;
        checker_black = target.GetComponent<GameProcess>().Chechs_black;

        bool beat = false;
        if (need_beat())
        {
            beat = true;
        }

        bool damka_can_beat = false;
        if (damka_need_beat())
        {
            damka_can_beat = true;
        }

        if (target.GetComponent<GameProcess>().play2/*player2.enabled*/)
        {
            // если игрок снова нажал на шашку, которая была нажата
            if (is_checker_active == true){
                new_move();
                is_checker_active = false;
            }
            else if(!is_damka)
            {
                new_move(); // удаляет все квадраты для хода на поле
                is_checker_active = true;
                // if cage is empty then create there square(object) for possible move
                if (move_access(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2) && !beat && !damka_can_beat) {
                    create_square(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2, false, false);
                }
                else if (is_wChacker_in_square(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2) && move_access(active_chacker.transform.position.x + 4, active_chacker.transform.position.y - 4)) {
                    create_square(active_chacker.transform.position.x + 4, active_chacker.transform.position.y - 4, true, false);
                    find_rmChecker_position(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2);
                }
                
                if (move_access(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2) && !beat && !damka_can_beat) {
                    create_square(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2, false, false);
                }
                else if (is_wChacker_in_square(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2) && move_access(active_chacker.transform.position.x - 4, active_chacker.transform.position.y - 4)) {
                    create_square(active_chacker.transform.position.x - 4, active_chacker.transform.position.y - 4, true, false);
                    find_rmChecker_position(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2);
                }

                if (is_wChacker_in_square(active_chacker.transform.position.x - 2, active_chacker.transform.position.y + 2) && move_access(active_chacker.transform.position.x - 4, active_chacker.transform.position.y + 4)) {
                    create_square(active_chacker.transform.position.x - 4, active_chacker.transform.position.y + 4, true, false);
                    find_rmChecker_position(active_chacker.transform.position.x - 2, active_chacker.transform.position.y + 2);
                }
                else if (is_wChacker_in_square(active_chacker.transform.position.x + 2, active_chacker.transform.position.y + 2) && move_access(active_chacker.transform.position.x + 4, active_chacker.transform.position.y + 4)) {
                    create_square(active_chacker.transform.position.x + 4, active_chacker.transform.position.y + 4, true, false);
                    find_rmChecker_position(active_chacker.transform.position.x + 2, active_chacker.transform.position.y + 2);
                }
            }
            else if(is_damka)
            {

                new_move();
                is_checker_active = true;
                if (move_access(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2))
                {
                    create_square(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2, false, true);
                }
                else if (is_bChacker_in_square(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2) && move_access(active_chacker.transform.position.x + 4, active_chacker.transform.position.y - 4))
                {
                    create_square(active_chacker.transform.position.x + 4, active_chacker.transform.position.y - 4, true, true);
                    find_rmChecker_position(active_chacker.transform.position.x + 2, active_chacker.transform.position.y - 2);
                }

                if (move_access(active_chacker.transform.position.x - 2, active_chacker.transform.position.y + 2))
                {
                    create_square(active_chacker.transform.position.x - 2, active_chacker.transform.position.y + 2, false, true);
                }
                else if (is_bChacker_in_square(active_chacker.transform.position.x - 2, active_chacker.transform.position.y + 2) && move_access(active_chacker.transform.position.x - 4, active_chacker.transform.position.y + 4))
                {
                    create_square(active_chacker.transform.position.x - 4, active_chacker.transform.position.y + 4, true, true);
                    find_rmChecker_position(active_chacker.transform.position.x - 2, active_chacker.transform.position.y + 2);
                }

                if (move_access(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2))
                {
                    create_square(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2, false, true);
                }
                else if (is_bChacker_in_square(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2) && move_access(active_chacker.transform.position.x - 4, active_chacker.transform.position.y - 4))
                {
                    create_square(active_chacker.transform.position.x - 4, active_chacker.transform.position.y - 4, true, true);
                    find_rmChecker_position(active_chacker.transform.position.x - 2, active_chacker.transform.position.y - 2);
                }

                if (move_access(active_chacker.transform.position.x + 2, active_chacker.transform.position.y + 2))
                {
                    create_square(active_chacker.transform.position.x + 2, active_chacker.transform.position.y + 2, false, true);
                }
                else if (is_bChacker_in_square(active_chacker.transform.position.x + 2, active_chacker.transform.position.y + 2) && move_access(active_chacker.transform.position.x + 4, active_chacker.transform.position.y + 4))
                {
                    create_square(active_chacker.transform.position.x + 4, active_chacker.transform.position.y + 4, true, true);
                    find_rmChecker_position(active_chacker.transform.position.x + 2, active_chacker.transform.position.y + 2);
                }
            }
        }
    }


    public bool need_beat()
    {
        bool need_beat = false;
        foreach (GameObject i in checker_black)
        {
            if (is_wChacker_in_square(i.transform.position.x + 2, i.transform.position.y + 2) && move_access(i.transform.position.x + 4, i.transform.position.y + 4) && i.active)
            {
                need_beat = true;
                break;
            }
            if (is_wChacker_in_square(i.transform.position.x - 2, i.transform.position.y + 2) && move_access(i.transform.position.x - 4, i.transform.position.y + 4) && i.active)
            {
                need_beat = true;
                break;
            }
            if (is_wChacker_in_square(i.transform.position.x + 2, i.transform.position.y - 2) && move_access(i.transform.position.x + 4, i.transform.position.y - 4) && i.active)
            {
                need_beat = true;
                break;
            }
            if (is_wChacker_in_square(i.transform.position.x - 2, i.transform.position.y - 2) && move_access(i.transform.position.x - 4, i.transform.position.y - 4) && i.active)
            {
                need_beat = true;
                break;
            }
        }
        return need_beat;
    }

    public void create_square(float x, float y, bool beat, bool is_damka)
    {
        empty_plases.Add(Instantiate(possible_move, (new Vector3(x, y, 0)), Quaternion.identity).gameObject);
        empty_plases[empty_plases.Count - 1].GetComponent<Square_hod>().square_current = empty_plases[empty_plases.Count - 1];
        empty_plases[empty_plases.Count - 1].GetComponent<Square_hod>().active_checker = active_chacker;
        empty_plases[empty_plases.Count - 1].GetComponent<Square_hod>().need_beat = beat;
        empty_plases[empty_plases.Count - 1].GetComponent<Square_hod>().activeCh_is_damka = is_damka;
    }


    public void make_damka(){
        is_damka = true;
        active_chacker.GetComponent<SpriteRenderer> ().sprite = damka_sprite;
	}

	public void find_rmChecker_position(float x, float y)
	{
		foreach (GameObject i in checker_white)
			if (i.transform.position.x == x && i.transform.position.y == y && i.activeInHierarchy) {
                empty_plases[empty_plases.Count - 1].GetComponent<Square_hod> ().chacker_to_remove = i;
				break;
			}
	}

	// проверяет можна ли пойти на выбраную клетку, зависит от координат
	public bool move_access(float x, float y)
	{
		if (!is_wChacker_in_square(x, y) && !is_bChacker_in_square(x, y) && Obj_h (x, y) && Out_range (x, y))
			return true;
		else
			return false;
	}

	//удаляет все квадраты на поле
	void new_move()
	{
		foreach (GameObject i in checker_white)
			if (i.GetComponent<Move_w> ().is_checker_active == true) {
				i.GetComponent<Move_w> ().is_checker_active = false;
				foreach (GameObject j in i.GetComponent<Move_w> ().empty_plases)
					Destroy (j);
				i.GetComponent<Move_w> ().empty_plases.Clear();
			}
		foreach (GameObject i in checker_black)
			if (i.GetComponent<Move_b> ().is_checker_active == true) {
				i.GetComponent<Move_b> ().is_checker_active = false;
				foreach (GameObject j in i.GetComponent<Move_b> ().empty_plases)
					Destroy (j);
				i.GetComponent<Move_b> ().empty_plases.Clear();
			}

        squares_who_need_destroy.Clear();
    }

	// проверяет нет ли на клетке белых шашек
	public bool is_wChacker_in_square(float x, float y)
	{
		foreach (GameObject i in checker_white) {
			if ((int) i.transform.position.x == (int) x && (int) i.transform.position.y == (int) y && i.activeInHierarchy)
				return true;
		}
		return false;
	}

	// проверяет нет ли на клетке шерных шашек
	public bool is_bChacker_in_square(float x, float y)
	{
		foreach (GameObject i in checker_black) {
			if ((int) i.transform.position.x == (int) x && (int) i.transform.position.y == (int) y && i.activeInHierarchy) 
				return true;
		}
		return false;
	}

	// проверяет нет ли на клетке других квадратов
	public bool Obj_h(float x, float y)
	{
		foreach (GameObject i in empty_plases) {
			if ((int) i.transform.position.x == (int) x &&(int)  i.transform.position.y == (int) y && i.activeInHierarchy) 
				return false;
		}
		return true;
	}

	// проверяет не выходит ли за поле
	public bool Out_range(float x, float y)
	{
		if (x < -8 || x > 8 || y < -8 || y > 8) 
			return false;
		else
			return true;
	}

    public bool damka_need_beat()
    {
        foreach (GameObject i in checker_black)
        {
            if (i.GetComponent<Move_b>().is_damka)
            {
                for (int x = 2, y = 2; x <= 16; x += 2, y += 2)
                {
                    if (is_bChacker_in_square(i.transform.position.x + x, i.transform.position.y + y) && move_access(i.transform.position.x + x + 2, i.transform.position.y + y + 2))
                    {
                        return true;
                    }
                }

                for (int x = 2, y = 2; x <= 16; x += 2, y += 2)
                {
                    if (is_bChacker_in_square(i.transform.position.x - x, i.transform.position.y - y) && move_access(i.transform.position.x - x - 2, i.transform.position.y - y - 2))
                    {
                        return true;
                    }
                }

                for (int x = 2, y = 2; x <= 16; x += 2, y += 2)
                {
                    if (is_bChacker_in_square(i.transform.position.x - x, i.transform.position.y + y) && move_access(i.transform.position.x - x - 2, i.transform.position.y + y + 2))
                    {
                        return true;
                    }
                }

                for (int x = 2, y = 2; x <= 16; x += 2, y += 2)
                {
                    if (is_bChacker_in_square(i.transform.position.x + x, i.transform.position.y - y) && move_access(i.transform.position.x + x + 2, i.transform.position.y - y - 2))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}