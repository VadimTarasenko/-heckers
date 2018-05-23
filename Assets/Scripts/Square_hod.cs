using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Square_hod : MonoBehaviour {
	public GameObject active_checker; // шашка, от которой был создан квадрат
	public GameObject square_current; // квадрат, тот в котором работает скрипт
    public bool activeCh_is_damka;
	public bool need_beat;
	private bool is_white = true;
	public GameObject chacker_to_remove; // враг которого нужно убрать с поля
    private List<GameObject> checker_white; // масив белых шашок
    private List<GameObject> checker_black; // масив черных шашок
    public GameObject prev;

    void Start () {
        GameProcess target = (GameProcess)FindObjectOfType (typeof(GameProcess));
        checker_white = target.GetComponent<GameProcess>().Chechs_white;
        checker_black = target.GetComponent<GameProcess>().Chechs_black;
        foreach (GameObject i in checker_black)
			if (active_checker == i) {
				is_white = false;
				break;
			}
        
        if (is_white && need_beat && !activeCh_is_damka) { 
			if (active_checker.GetComponent<Move_w> ().is_bChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y + 2)
                && active_checker.GetComponent<Move_w> ().move_access(square_current.transform.position.x + 4, square_current.transform.position.y + 4)) {

                create_square_if_nead_beat_for_white(square_current.transform.position.x + 4, square_current.transform.position.y + 4, true, false);
                active_checker.GetComponent<Move_w> ().find_rmChecker_position(square_current.transform.position.x + 2, square_current.transform.position.y + 2);
			}

			if (active_checker.GetComponent<Move_w> ().is_bChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y + 2)
                && active_checker.GetComponent<Move_w> ().move_access(square_current.transform.position.x - 4, square_current.transform.position.y + 4)) {
         
                create_square_if_nead_beat_for_white(square_current.transform.position.x - 4, square_current.transform.position.y + 4, true, false);
                active_checker.GetComponent<Move_w> ().find_rmChecker_position(square_current.transform.position.x - 2, square_current.transform.position.y + 2);
			}
		
			if (active_checker.GetComponent<Move_w> ().is_bChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y - 2) 
                && active_checker.GetComponent<Move_w> ().move_access(square_current.transform.position.x + 4, square_current.transform.position.y - 4)) {

                create_square_if_nead_beat_for_white(square_current.transform.position.x + 4, square_current.transform.position.y - 4, true, false);
                active_checker.GetComponent<Move_w> ().find_rmChecker_position(square_current.transform.position.x + 2, square_current.transform.position.y - 2);
			}

			if (active_checker.GetComponent<Move_w> ().is_bChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y - 2) 
                && active_checker.GetComponent<Move_w> ().move_access(square_current.transform.position.x - 4, square_current.transform.position.y - 4)) {
           
                create_square_if_nead_beat_for_white(square_current.transform.position.x - 4, square_current.transform.position.y - 4, true, false);
                active_checker.GetComponent<Move_w> ().find_rmChecker_position(square_current.transform.position.x - 2, square_current.transform.position.y - 2);
			}

		} else if (!is_white && need_beat && !activeCh_is_damka) {
            // 
			if (active_checker.GetComponent<Move_b> ().is_wChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y + 2) && active_checker.GetComponent<Move_b> ().move_access(square_current.transform.position.x + 4, square_current.transform.position.y + 4)) {
    
                create_square_if_nead_beat_for_black(square_current.transform.position.x + 4, square_current.transform.position.y + 4, true, false);
                active_checker.GetComponent<Move_b> ().find_rmChecker_position(square_current.transform.position.x + 2, square_current.transform.position.y + 2);
			}

			if (active_checker.GetComponent<Move_b> ().is_wChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y + 2) && active_checker.GetComponent<Move_b> ().move_access(square_current.transform.position.x - 4, square_current.transform.position.y + 4)) {
                
                create_square_if_nead_beat_for_black(square_current.transform.position.x - 4, square_current.transform.position.y + 4, true, false);
                active_checker.GetComponent<Move_b> ().find_rmChecker_position(square_current.transform.position.x - 2, square_current.transform.position.y + 2);
			}

			if (active_checker.GetComponent<Move_b> ().is_wChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y - 2) && active_checker.GetComponent<Move_b> ().move_access(square_current.transform.position.x + 4, square_current.transform.position.y - 4)) {
                
                create_square_if_nead_beat_for_black(square_current.transform.position.x + 4, square_current.transform.position.y - 4, true, false);
                active_checker.GetComponent<Move_b> ().find_rmChecker_position(square_current.transform.position.x + 2, square_current.transform.position.y - 2);
			}

			if (active_checker.GetComponent<Move_b> ().is_wChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y - 2) && active_checker.GetComponent<Move_b> ().move_access(square_current.transform.position.x - 4, square_current.transform.position.y - 4)) {
             
                create_square_if_nead_beat_for_black(square_current.transform.position.x - 4, square_current.transform.position.y - 4, true, false);
                active_checker.GetComponent<Move_b> ().find_rmChecker_position(square_current.transform.position.x - 2, square_current.transform.position.y - 2);
			}
		}

        else if(is_white && activeCh_is_damka && !need_beat)
        {
            if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
            {
                if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f))
                {
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f, false, true);
                }
                else if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f)
                    && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 4f, square_current.transform.position.y + 4f))
                {
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 4f, square_current.transform.position.y + 4f, true, true);
                    active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f);
                }
            }
            if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
            {
                if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f))
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f, false, true);
                else if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f)
                    && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 4f, square_current.transform.position.y - 4f))
                {
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 4f, square_current.transform.position.y - 4f, true, true);
                    active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f);
                }
            }
            if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
            {
                if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f))
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f, false, true);
                else if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f)
                    && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 4f, square_current.transform.position.y + 4f))
                {
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 4f, square_current.transform.position.y + 4f, true, true);
                    active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f);
                }
            }
            if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
            {
                if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f))
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f, false, true);
                else if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f)
                    && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 4f, square_current.transform.position.y - 4f))
                {
                    active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 4f, square_current.transform.position.y - 4f, true, true);
                    active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f);
                }
            }
        }
        else if(is_white && activeCh_is_damka && need_beat)
        {
            active_checker.GetComponent<Move_w>().squares_who_need_destroy.Add(square_current);


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // двойний бій
            bool flag = true;
            if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y + 2)
                && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 4, square_current.transform.position.y + 4))
            {
                active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 4, square_current.transform.position.y + 4, true, true);
                active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y - 2)
                && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 4, square_current.transform.position.y - 4))
            {
                active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 4, square_current.transform.position.y - 4, true, true);
                active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y + 2)
                && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 4, square_current.transform.position.y + 4))
            {
                active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 4, square_current.transform.position.y + 4, true, true);
                active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            if (active_checker.GetComponent<Move_w>().is_bChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y - 2)
                && active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 4, square_current.transform.position.y - 4))
            {
                active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 4, square_current.transform.position.y - 4, true, true);
                active_checker.GetComponent<Move_w>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (flag && !GameProcess.double_damka_move)
            {
                if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
                {
                    if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f))
                    {
                        active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f, true, true);
                    }
                }
                if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
                {
                    if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f))
                    {
                        active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f, true, true);
                    }

                }
                if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
                {
                    if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f))
                    {
                        active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f, true, true);
                    }

                }
                if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
                {
                    if (active_checker.GetComponent<Move_w>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f))
                    {
                        active_checker.GetComponent<Move_w>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f, true, true);
                    }
                }
            }

            // 
            if_need_beat_wDamka();
        }

        // black checker
        else if (!is_white && activeCh_is_damka && !need_beat)
        {
            if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
            {
                if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f))
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f, false, true);
                else if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f)
                    && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 4f, square_current.transform.position.y + 4f))
                {
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 4f, square_current.transform.position.y + 4f, true, true);
                    active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f);
                }
            }
            if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
            {
                if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f))
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f, false, true);
                else if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f)
                    && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 4f, square_current.transform.position.y - 4f))
                {
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 4f, square_current.transform.position.y - 4f, true, true);
                    active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f);
                }
            }
            if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
            {
                if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f))
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f, false, true);
                else if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f)
                    && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 4f, square_current.transform.position.y + 4f))
                {
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 4f, square_current.transform.position.y + 4f, true, true);
                    active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f);
                }
            }
            if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
            {
                if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f))
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f, false, true);
                else if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f)
                    && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 4f, square_current.transform.position.y - 4f))
                {
                    active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 4f, square_current.transform.position.y - 4f, true, true);
                    active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f);
                }
            }
        }
        else if (!is_white && activeCh_is_damka && need_beat)
        {
            active_checker.GetComponent<Move_b>().squares_who_need_destroy.Add(square_current);
            
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // двойний бій
            bool flag = true;
            if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y + 2)
                && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 4, square_current.transform.position.y + 4))
            {
                active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 4, square_current.transform.position.y + 4, true, true);
                active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x + 2, square_current.transform.position.y - 2)
                && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 4, square_current.transform.position.y - 4))
            {
                active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 4, square_current.transform.position.y - 4, true, true);
                active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y + 2)
                && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 4, square_current.transform.position.y + 4))
            {
                active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 4, square_current.transform.position.y + 4, true, true);
                active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            if (active_checker.GetComponent<Move_b>().is_wChacker_in_square(square_current.transform.position.x - 2, square_current.transform.position.y - 2)
                && active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 4, square_current.transform.position.y - 4))
            {
                active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 4, square_current.transform.position.y - 4, true, true);
                active_checker.GetComponent<Move_b>().find_rmChecker_position(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f);
                GameProcess.double_damka_move = true;
                flag = false;
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (flag && !GameProcess.double_damka_move)
            {
                if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
                {
                    if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f))
                    {
                        active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y + 2f, true, true);
                    }
                }
                if ((square_current.transform.position.x - active_checker.transform.position.x) > 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
                {
                    if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f))
                    {
                        active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x + 2f, square_current.transform.position.y - 2f, true, true);
                    }

                }
                if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) > 0)
                {
                    if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f))
                    {
                        active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y + 2f, true, true);
                    }

                }
                if ((square_current.transform.position.x - active_checker.transform.position.x) < 0
                    && (square_current.transform.position.y - active_checker.transform.position.y) < 0)
                {
                    if (active_checker.GetComponent<Move_b>().move_access(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f))
                    {
                        active_checker.GetComponent<Move_b>().create_square(square_current.transform.position.x - 2f, square_current.transform.position.y - 2f, true, true);
                    }
                }
            }
            if_need_beat_bDamka();
        }
    }

	void OnMouseDown()
	{
        GameProcess target = (GameProcess)FindObjectOfType (typeof(GameProcess));
		if (target.GetComponent<GameProcess> ().play1) {
			target.GetComponent<GameProcess> ().play1 = false;
			target.GetComponent<GameProcess> ().play2 = true;
            target.GetComponent<GameProcess>().mainCamera.GetComponent<Animation>().Play("Player1WasMove");
        } else {
			target.GetComponent<GameProcess> ().play2 = false;
			target.GetComponent<GameProcess> ().play1 = true;
            target.GetComponent<GameProcess>().mainCamera.GetComponent<Animation>().Play("Player2WasMove");
        }                                                                               
		if (is_white) {
			if (square_current.transform.position.y > 6)
                active_checker.GetComponent<Move_w> ().make_damka();
            active_checker.GetComponent<Move_w> ().is_checker_active = false;
            active_checker.transform.position = new Vector3 (square_current.transform.position.x, square_current.transform.position.y, 0);
            
            Destroy_enemy();
            if(active_checker.GetComponent<Move_w>().is_damka)
            {
                bool All_destroy = false;
                foreach (GameObject i in active_checker.GetComponent<Move_w>().squares_who_need_destroy) {
                    if (i.transform.position.x == square_current.transform.position.x && i.transform.position.y == square_current.transform.position.y) {
                        All_destroy = true;
                        break;
                    }
                }
                if (All_destroy) {
                    foreach (GameObject i in active_checker.GetComponent<Move_w>().squares_who_need_destroy) {
                        i.GetComponent<Square_hod>().Destroy_enemy();
                    }
                    All_destroy = false;
                }
            }
            
            foreach (GameObject i in active_checker.GetComponent<Move_w> ().empty_plases) {
                Destroy(i);
            }

            
            active_checker.GetComponent<Move_w>().squares_who_need_destroy.Clear();
            active_checker.GetComponent<Move_w> ().empty_plases.Clear ();
		} else {
			if (square_current.transform.position.y < -6)
                active_checker.GetComponent<Move_b> ().make_damka();
            active_checker.GetComponent<Move_b> ().is_checker_active = false;
            active_checker.transform.position = new Vector3 (square_current.transform.position.x, square_current.transform.position.y, 0);

			Destroy_enemy ();
            if (active_checker.GetComponent<Move_b>().is_damka) {
                bool All_destroy = false;
                foreach (GameObject i in active_checker.GetComponent<Move_b>().squares_who_need_destroy) {
                    if (i.transform.position.x == square_current.transform.position.x && i.transform.position.y == square_current.transform.position.y) {
                        All_destroy = true;
                        break;
                    }
                }
                if (All_destroy) {
                    foreach (GameObject i in active_checker.GetComponent<Move_b>().squares_who_need_destroy) {
                        i.GetComponent<Square_hod>().Destroy_enemy();
                    }
                    All_destroy = false;
                }
            }
            foreach (GameObject i in active_checker.GetComponent<Move_b> ().empty_plases) {
                Destroy(i);
            }

            active_checker.GetComponent<Move_b>().squares_who_need_destroy.Clear();
            active_checker.GetComponent<Move_b> ().empty_plases.Clear ();
        }




        GameProcess.double_damka_move = false;
        // перевірка на кінець гри
        checkWins();
    }

    public void create_square_if_nead_beat_for_white(float x, float y, bool beat, bool damka) {
        active_checker.GetComponent<Move_w>().empty_plases.Add(Instantiate(active_checker.GetComponent<Move_w>().possible_move, (new Vector3(x, y, 0)), Quaternion.identity).gameObject);
        active_checker.GetComponent<Move_w>().empty_plases[active_checker.GetComponent<Move_w>().empty_plases.Count - 1].GetComponent<Square_hod>().square_current = active_checker.GetComponent<Move_w>().empty_plases[active_checker.GetComponent<Move_w>().empty_plases.Count - 1];
        active_checker.GetComponent<Move_w>().empty_plases[active_checker.GetComponent<Move_w>().empty_plases.Count - 1].GetComponent<Square_hod>().active_checker = active_checker;
        active_checker.GetComponent<Move_w>().empty_plases[active_checker.GetComponent<Move_w>().empty_plases.Count - 1].GetComponent<Square_hod>().prev = square_current;
        active_checker.GetComponent<Move_w>().empty_plases[active_checker.GetComponent<Move_w>().empty_plases.Count - 1].GetComponent<Square_hod>().need_beat = beat;
        need_beat = beat;
        active_checker.GetComponent<Move_w>().empty_plases[active_checker.GetComponent<Move_w>().empty_plases.Count - 1].GetComponent<Square_hod>().activeCh_is_damka = damka;
    }

    public void create_square_if_nead_beat_for_black(float x, float y, bool beat, bool damka)
    {
        active_checker.GetComponent<Move_b>().empty_plases.Add(Instantiate(active_checker.GetComponent<Move_b>().possible_move, (new Vector3(x, y, 0)), Quaternion.identity).gameObject);
        active_checker.GetComponent<Move_b>().empty_plases[active_checker.GetComponent<Move_b>().empty_plases.Count - 1].GetComponent<Square_hod>().square_current = active_checker.GetComponent<Move_b>().empty_plases[active_checker.GetComponent<Move_b>().empty_plases.Count - 1];
        active_checker.GetComponent<Move_b>().empty_plases[active_checker.GetComponent<Move_b>().empty_plases.Count - 1].GetComponent<Square_hod>().active_checker = active_checker;
        active_checker.GetComponent<Move_b>().empty_plases[active_checker.GetComponent<Move_b>().empty_plases.Count - 1].GetComponent<Square_hod>().prev = square_current;
        active_checker.GetComponent<Move_b>().empty_plases[active_checker.GetComponent<Move_b>().empty_plases.Count - 1].GetComponent<Square_hod>().need_beat = beat;
        need_beat = beat;
        active_checker.GetComponent<Move_b>().empty_plases[active_checker.GetComponent<Move_b>().empty_plases.Count - 1].GetComponent<Square_hod>().activeCh_is_damka = damka;
    }

    public void Destroy_enemy() {
		if (is_white && square_current.transform.position.y > 6) {
            active_checker.GetComponent<Move_w> ().make_damka();
		} else if (square_current.transform.position.y < -6)
            active_checker.GetComponent<Move_b> ().make_damka();
		if (chacker_to_remove != null)
            chacker_to_remove.SetActive (false);
		if (prev != null)
			prev.GetComponent<Square_hod> ().Destroy_enemy ();
	}

    public void checkWins() {
        int count_active_ch = 0;
        foreach (GameObject i in checker_white) {
            if (i.active){
                count_active_ch++;
            }
        }
        if (count_active_ch == 0){
            Application.LoadLevel("BlackWin");
        }
        else
            count_active_ch = 0;

        foreach (GameObject i in checker_black) {
            if (i.active){
                count_active_ch++;
            }
        }
        if (count_active_ch == 0){
            Application.LoadLevel("WhiteWin");
        }
    }

    public void if_need_beat_wDamka()
    {
        if(active_checker.GetComponent<Move_w>().squares_who_need_destroy.Count > 0)
        {
            bool flag = true;
            foreach (GameObject i in active_checker.GetComponent<Move_w>().empty_plases)
            {
                foreach (GameObject j in active_checker.GetComponent<Move_w>().squares_who_need_destroy)
                {
                    if(i == j)
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag)
                {
                    i.SetActive(false);
                }
            }
            
        }
    }

    public void if_need_beat_bDamka()
    {
        if (active_checker.GetComponent<Move_b>().squares_who_need_destroy.Count > 0)
        {

            bool flag = true;
            foreach (GameObject i in active_checker.GetComponent<Move_b>().empty_plases)
            {
                foreach (GameObject j in active_checker.GetComponent<Move_b>().squares_who_need_destroy)
                {
                    if (i == j)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    i.SetActive(false);
                }
            }

        }
    }
}