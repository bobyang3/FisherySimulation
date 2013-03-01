#V3.24f-win64
#Sardine 2012 Update Model X6e1
#_SS-V3.24f-safe-win64;_04/23/2011;_Stock_Synthesis_by_Richard_Methot_(NOAA)_using_ADMB
1 #_N_Growth_Patterns
1 #_N_Morphs_Within_GrowthPattern 
#_Cond 1 #_Morph_between/within_stdev_ratio (no read if N_morphs=1)
#_Cond  1 #vector_Morphdist_(-1_in_first_val_gives_normal_approx)
#
1 # number of recruitment assignments (overrides GP*area*seas parameter values) 
0 # recruitment interaction requested
# GP seas area for each recruitment assignment
1 1 1
#
#_Cond 0 # N_movement_definitions goes here if N_areas > 1
#_Cond 1.0 # first age that moves (real age at begin of season, not integer) also cond on do_migration>0
#_Cond 1 1 1 2 4 10 # example move definition for seas=1, morph=1, source=1 dest=2, age1=4, age2=10
#
1 #_Nblock_Patterns
1 #_blocks_per_pattern
# begin and end years of blocks
1999 2012 #_MexCal_selex 
#
0.5 #_fracfemale 
0 #_natM_type:_0=1Parm; 1=N_breakpoints;_2=Lorenzen;_3=agespecific;_4=agespec_withseasinterpolate
  #_no additional input for selected M option; read 1P per morph
1 # GrowthModel: 1=vonBert with L1&L2; 2=Richards with L1&L2; 3=not implemented; 4=not implemented
0.5 #_Growth_Age_for_L1
999 #_Growth_Age_for_L2 15 (999 to use as Linf)
0 #_SD_add_to_LAA (set to 0.1 for SS2 V1.x compatibility)
0 #_CV_Growth_Pattern:  0 CV=f(LAA); 1 CV=F(A); 2 SD=F(LAA); 3 SD=F(A); 4 logSD=F(A)
1 #_maturity_option:  1=length logistic; 2=age logistic; 3=read age-maturity matrix by growth_pattern; 4=read age-fecundity; 5=read fec and wt from wtatage.ss
#_placeholder for empirical age-maturity by growth pattern
0 #_First_Mature_Age
1 #_fecundity option:(1)eggs=Wt*(a+b*Wt);(2)eggs=a*L^b;(3)eggs=a*Wt^b; (4)eggs=a+b*L; (5)eggs=a+b*W
0 #_hermaphroditism option:  0=none; 1=age-specific fxn
1 #_parameter_offset_approach (1=none, 2= M, G, CV_G as offset from female-GP1, 3=like SS2 V1.x)
1 #_env/block/dev_adjust_method (1=standard; 2=logistic transform keeps in base parm bounds; 3=standard w/ no bound check)
#
#_growth_parms
#_LO HI INIT PRIOR PR_type SD PHASE env-var use_dev dev_minyr dev_maxyr dev_stddev Block Block_Fxn
 0.3 0.7 0.4 0 -1 99 -3 0 0 0 0 0 0 0 # NatM_p_1_Fem_GP_1
 3 15 10 0 -1 99 3 0 0 0 0 0 0 0 # L_at_Amin_Fem_GP_1
 20 30 25 0 -1 99 3 0 0 0 0 0 0 0 # L_at_Amax_Fem_GP_1
 0.05 0.99 0.4 0 -1 99 3 0 0 0 0 0 0 0 # VonBert_K_Fem_GP_1
 0.05 0.3 0.14 0 -1 99 3 0 0 0 0 0 0 0 # CV_young_Fem_GP_1
 0.01 0.1 0.05 0 -1 99 3 0 0 0 0 0 0 0 # CV_old_Fem_GP_1
 -3 3 1.68384e-005 0 -1 99 -3 0 0 0 0 0 0 0 # Wtlen_1_Fem
 -3 5 2.948247 0 -1 99 -3 0 0 0 0 0 0 0 # Wtlen_2_Fem
 9 19 15.88 0 -1 99 -3 0 0 0 0 0 0 0 # Mat50%_Fem        
 -20 3 -0.90461 0 -1 99 -3 0 0 0 0 0 0 0 # Mat_slope_Fem 
 0 10 1 0 -1 99 -3 0 0 0 0 0 0 0 # Eggs/kg_inter_Fem
 -1 5 0 0 -1 99 -3 0 0 0 0 0 0 0 # Eggs/kg_slope_wt_Fem
 -4 4 0 0 -1 99 -3 0 0 0 0 0 0 0 # RecrDist_GP_1
 -4 4 1 0 -1 99 -3 0 0 0 0 0 0 0 # RecrDist_Area_1
 -4 4 1 0 -1 99 -3 0 0 0 0 0 0 0 # RecrDist_Seas_1
 -4 4 0 0 -1 99 -3 0 0 0 0 0 0 0 # RecrDist_Seas_2
 1 1 1 0 -1 99 -3 0 0 0 0 0 0 0 # CohortGrowDev
#
#_Cond 0  #custom_MG-env_setup (0/1)
#
#_Cond -2 2 0 0 -1 99 -2 #_placeholder when no MG-environ parameters
#
# 1 #_custom_MG-block_setup (0/1)
#_Cond No MG parm trends 
#
#_seasonal_effects_on_biology_parms
 0 0 0 0 0 0 0 0 0 0 #_femwtlen1,femwtlen2,mat1,mat2,fec1,fec2,Malewtlen1,malewtlen2,L1,K
#_Cond -2 2 0 0 -1 99 -2 #_placeholder when no seasonal MG parameters
#
#_Cond -4 #_MGparm_Dev_Phase
#
#_Spawner-Recruitment
2 #_SR_function: 1=B-H_flattop; 2=Ricker; 3=std_B-H; 4=CAA; 5=Hockey; 6=Shepard_3Parm
#_LO HI INIT PRIOR PR_type SD PHASE
3 25 16 0 -1 99 1 # SR_R0
0.2 4 2.5 0 -1 99 6 # SR_steep Ricker
0 2 0.727 0 -1 99 -3 # SR_sigmaR (FINAL_X5=0.622)
-5 5 0 0 -1 99 -3 # SR_envlink
-15 15 0 0 -1 99 2 # SR_R1_offset
0 0 0 0 -1 99 -3 # SR_autocorr
0 #_SR_env_link
0 #_SR_env_target_0=none;1=devs;_2=R0;_3=steepness
1 #do_recdev:  0=none; 1=devvector; 2=simple deviations
1993 #_first year of main recr_devs; early devs can preceed this era (FINAL_X5=1993)
2010 #_last year of main recr_devs; forecast devs start in following year (FINAL_X5=2008)
1 #_recdev phase 
1 # (0/1) to read 13 advanced options
-6 # -6 _recdev_early_start (0=none; neg value makes relative to recdev_start)
2 # 2 _recdev_early_phase
0 # 0 _forecast_recruitment phase (incl. late recr) (0 value resets to maxphase+1)
1 # 1 _lambda for Fcast_recr_like occurring before endyr+1
1987 #_last_early_yr_nobias_adj_in_MPD (FINAL_X5=1987)
1994 #_first_yr_fullbias_adj_in_MPD (FINAL_X5=1994)
2010 #_last_yr_fullbias_adj_in_MPD (FINAL_X5=2008)
2011 #_first_recent_yr_nobias_adj_in_MPD (FINAL_X5=2009)
0.9 # 1 0.9 _max_bias_adj_in_MPD (-1 to override ramp and set biasadj=1.0 for all estimated recdevs)
0 #_period of cycles in recruitment (N parms read below)
-5 #min rec_dev
5 #max rec_dev
0 #_read_recdevs
#_end of advanced SR options
#
#_placeholder for full parameter lines for recruitment cycles
# read specified recr devs
#_Yr Input_value
#
#
#Fishing Mortality info 
0.1 # F ballpark for tuning early phases
-2006 # F ballpark year (neg value to disable)
3 # F_Method:  1=Pope; 2=instan. F; 3=hybrid (hybrid is recommended)
4 # max F or harvest rate, depends on F_Method
# no additional F input needed for Fmethod 1
# if Fmethod=2; read overall start F value; overall phase; N detailed inputs to read
# if Fmethod=3; read N iterations for tuning for Fmethod 3
10  # N iterations for tuning F in hybrid method (recommend 3 to 7)
#
#_initial_F_parms
#_LO HI INIT PRIOR PR_type SD PHASE
0 4 0 0 -1 99 -1 # InitF_1MexCal_S1
0 4 0 0 -1 99 -1 # InitF_2MexCal_S2
0 4 0 0 -1 99 -1 # InitF_3PacNW
#
#_Q_setup
 # Q_type options:  <0=mirror, 0=median_float, 1=mean_float, 2=parameter, 3=parm_w_random_dev, 4=parm_w_randwalk, 5=mean_unbiased_float_assign_to_parm
 #_Den-dep  env-var  extra_se  Q_type
0 0 0 0 # 1 MexCal_S1
0 0 0 0 # 2 MexCal_S2
0 0 0 0 # 3 PacNW
0 0 0 2 # 4 DEPM
0 0 0 2 # 5 TEP
0 0 0 2 # 6 TEP_all
0 0 0 2 # 7 Aerial
0 0 0 2 # 8 Acoustic
#
#_Cond 0 #_If q has random component, then 0=read one parm for each fleet with random q; 1=read a parm for each year of index
#_Q_parms(if_any)
# LO HI INIT PRIOR PR_type SD PHASE
-3 3 -1.39 0 -1 99 5 # Q_base_8_DEPM
-3 3 -0.69 0 -1 99 5 # Q_base_9_TEP
-3 3 -0.69 0 -1 99 5 # Q_base_9_TEP_all
-3 3 0 0 -1 99 5 # Q_base_10_Aerial
-3 3 0 0 -1 99 -5 # Q_base_11_Acoustic
#
#_size_selex_types
#_Pattern Discard Male Special
24 0 0 0 # 1 MexCal_S1
24 0 0 0 # 2 MexCal_S2
1 0 0 0 # 3 PacNW
30 0 0 0 # 4 DEPM
30 0 0 0 # 5 TEP
30 0 0 0 # 6 TEP_full
24 0 0 0 # 7 Aerial 15 0 0 3
24 0 0 0 # 8 Acoustic
#
#_age_selex_types
#_Pattern ___ Male Special
11 0 0 0 # 1 MexCal_S1
11 0 0 0 # 2 MexCal_S2
11 0 0 0 # 3 PacNW
11 0 0 0 # 4 DEPM
11 0 0 0 # 5 TEP
11 0 0 0 # 6 TEP_full
11 0 0 0 # 7 Aerial
11 0 0 0 # 8 Acoustic
#_LO HI INIT PRIOR PR_type SD PHASE env-var use_dev dev_minyr dev_maxyr dev_stddev Block Block_Fxn
#_MexCal_S1_Baseline_Selex
 10 28 18 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_1_MexCal_S1
 -5 3 3 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_2_MexCal_S1
 -1 9 2.5 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_3_MexCal_S1
 -1 9 4 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_4_MexCal_S1
 -10 10 -10 0 -1 99 -4 0 0 0 0 0 1 2 # SizeSel_2P_5_MexCal_S1
 -10 10 10 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_6_MexCal_S1
#_MexCal_S2_Baseline_Selex
 10 28 18 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_1_MexCal_S2
 -5 3 -4.9 0 -1 99 -4 0 0 0 0 0 1 2 # SizeSel_2P_2_MexCal_S2
 -1 9 2.5 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_3_MexCal_S2
 -1 9 4 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_4_MexCal_S2
 -10 10 -10 0 -1 99 -4 0 0 0 0 0 1 2 # SizeSel_2P_5_MexCal_S2
 -10 10 10 0 -1 99 4 0 0 0 0 0 1 2 # SizeSel_2P_6_MexCal_S2
#_PacNW_Baseline_Selex
 10 28 18 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_6P_1_PacNW_logistic
 1 16 4 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_6P_2_PacNW_logistic
#_Aerial_Baseline_Selex
 10 28 18 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_2P_1_Aerial
 -5 3 3 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_2P_2_Aerial
 -1 9 2.5 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_2P_3_Aerial
 -1 9 4 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_2P_4_Aerial
 -10 10 -10 0 -1 99 -4 0 0 0 0 0 0 0 # SizeSel_2P_5_Aerial
 -10 10 10 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_2P_6_Aerial
#_Acoustic_Baseline_Selex
 10 28 18 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_8P_1_Acoustic
 -5 3 3 0 -1 99 -4 0 0 0 0 0 0 0 # SizeSel_8P_2_Acoustic
 -1 9 2.5 0 -1 99 4 0 0 0 0 0 0 0 # SizeSel_8P_3_Acoustic
 -1 9 4 0 -1 99 -4 0 0 0 0 0 0 0 # SizeSel_8P_4_Acoustic
 -10 10 -10 0 -1 99 -4 0 0 0 0 0 0 0 # SizeSel_8P_5_Acoustic
 -10 10 10 0 -1 99 -4 0 0 0 0 0 0 0 # SizeSel_8P_6_Acoustic
#_Age_Selex_Basline
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_2P_1_MexCal_S1
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_2P_2_MexCal_S1
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_3P_1_MexCal_S2
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_3P_2_MexCal_S2
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_6P_1_PacNW
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_6P_2_PacNW
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_8P_1_DEPM
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_8P_2_DEPM
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_9P_1_TEP
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_9P_2_TEP
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_9P_1_TEP_full
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_9P_2_TEP_full
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_10P_1_Aerial
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_10P_2_Aerial
 0 15 0 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_11P_1_Acoustic
 0 15 15 0 -1 99 -4 0 0 0 0 0 0 0 # AgeSel_11P_2_Acoustic
#
#_Cond 0 #_custom_sel-env_setup (0/1) 
#_Cond -2 2 0 0 -1 99 -2 #_placeholder when no enviro fxns
1 #_custom_sel-blk_setup (0/1) 
#_MexCal_S1_Block_2_Selex
 10 28 18 0 -1 99 4 # SizeSel_1P_1_MexCal_S1_BLK2repl_1999
 -5 3 -5 0 -1 99 -4 # SizeSel_1P_2_MexCal_S1_BLK2repl_1999
 -1 9 2.5 0 -1 99 4 # SizeSel_1P_3_MexCal_S1_BLK2repl_1999
 -1 9 4 0 -1 99 4 # SizeSel_1P_4_MexCal_S1_BLK2repl_1999
 -10 10 -10 0 -1 99 -4 # SizeSel_1P_5_MexCal_S1_BLK2repl_1999
 -10 10 10 0 -1 99 4 # SizeSel_1P_6_MexCal_S1_BLK2repl_1999
#_MexCal_S2_Block_2_Selex
 10 28 18 0 -1 99 4 # SizeSel_2P_1_MexCal_S2_BLK2repl_1999
 -5 3 -5 0 -1 99 -4 # SizeSel_2P_2_MexCal_S2_BLK2repl_1999
 -1 9 2.5 0 -1 99 4 # SizeSel_2P_3_MexCal_S2_BLK2repl_1999
 -1 9 4 0 -1 99 4 # SizeSel_2P_4_MexCal_S2_BLK2repl_1999
 -10 10 -10 0 -1 99 -4 # SizeSel_2P_5_MexCal_S2_BLK2repl_1999
 -10 10 10 0 -1 99 4 # SizeSel_2P_6_MexCal_S2_BLK2repl_1999
#
#_Cond No selex parm trends 
#_Cond -4 # placeholder for selparm_Dev_Phase
1 #_env/block/dev_adjust_method (1=standard; 2=logistic trans to keep in base parm bounds; 3=standard w/ no bound check)
#
# Tag loss and Tag reporting parameters go next
0  # TG_custom:  0=no read; 1=read if tags exist
#_Cond -6 6 1 1 2 0.01 -4 0 0 0 0 0 0 0  #_placeholder if no parameters
#
1 #_Variance_adjustments_to_input_values
#_fleet: 1 2 3 4 5 6 7 8
0.000000	0.000000	0.000000	0.404505	0.347977	0.000000	0.349533	0.221872	#_add_to_survey_CV
0.000000	0.000000	0.000000	0.000000	0.000000	0.000000	0.000000	0.000000	#_add_to_discard_stddev
0.000000	0.000000	0.000000	0.000000	0.000000	0.000000	0.000000	0.000000	#_add_to_bodywt_CV
1.860953	1.722981	0.602769	1.000000	1.000000	1.000000	0.584194	3.197891	#_mult_by_lencomp_N
0.800000	0.800000	0.250000	1.000000	1.000000	1.000000	1.000000	0.250000	#_mult_by_agecomp_N
1.000000	1.000000	1.000000	1.000000	1.000000	1.000000	1.000000	1.000000	#_mult_by_size-at-age_N
#
1 #_maxlambdaphase
1 #_sd_offset
#
17 # number of changes to make to default Lambdas (default value is 1.0)
# Like_comp codes:  1=surv; 2=disc; 3=mnwt; 4=length; 5=age; 6=SizeFreq; 7=sizeage; 8=catch; 
# 9=init_equ_catch; 10=recrdev; 11=parm_prior; 12=parm_dev; 13=CrashPen; 14=Morphcomp; 15=Tag-comp; 16=Tag-negbin
#like_comp fleet/survey  phase  value  sizefreq_method
 1 4 1 1 1	#_DEPM
 1 5 1 1 1	#_TEP
 1 6 1 0 1	#_TEP_full
 1 7 1 1 1	#_Aerial
 1 8 1 1 1	#_Acoustic
 4 1 1 1 1	#_MexCal-S1_lengths
 4 2 1 1 1	#_MexCal-S2_lengths
 4 3 1 1 1	#_PacNW_lengths
 4 7 1 1 1	#_Aerial_lengths
 4 8 1 1 1	#_Acoustic_lengths
 5 1 1 1 1	#_MexCal-S1_CondAL
 5 2 1 1 1	#_MexCal-S2_CondAL
 5 3 1 1 1	#_PacNW_CondAL
 5 8 1 1 1  #_Acoustic_CondAL
 9 1 1 0 1  #_init_equ_catch_MexCal-S1
 9 2 1 0 1  #_init_equ_catch_MexCal-S2
 9 3 1 0 1  #_init_equ_catch_PacNW
#
0 # (0/1) read specs for more stddev reporting 
 # 0 1 -1 5 1 5 1 -1 5 # placeholder for selex type, len/age, year, N selex bins, Growth pattern, N growth ages, NatAge_area(-1 for all), NatAge_yr, N Natages
 # placeholder for vector of selex bins to be reported
 # placeholder for vector of growth ages to be reported
 # placeholder for vector of NatAges ages to be reported
999
