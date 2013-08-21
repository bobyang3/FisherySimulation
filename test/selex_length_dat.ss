#C data file for model showing different selectivities
#
2001 #_start_year
2012 #_ending_year
1 #_number_of_seasons
12 #_months_per_season
1 #_spawning_seas
5 #_N_fishing_fleets
0 #_N_surveys
1 #_N_areas
Type1_size_logistic%Type6_size_non-parametric%Type24_size_double-normal%Type25_size_exponential-logistic%Type27_size_cubic-spline #_fleetnames
0.5 0.5 0.5 0.5 0.5 #_surveytiming_in_season
1   1   1   1   1   #_area_assignments_for_each_fishery_and_survey
1   1   1   1   1   #_units of catch:  1=bio; 2=num
0.1 0.1 0.1 0.1 0.1 #_se of log(catch) only used for init_eq_catch and for Fmethod 2 and 3
2 #_Ngenders
20 #_Nages
0 0 0 0 0 #_init_equil_catch_for_each_fishery
12 #_N_lines_of_catch_to_read
#Fleet1 Fleet2 Fleet3 Fleet4 Fleet5  Year    Season
 1000   1000   1000   1000   1000    2001    1
 1000   1000   1000   1000   1000    2002    1
 1000   1000   1000   1000   1000    2003    1
 1000   1000   1000   1000   1000    2004    1
 1000   1000   1000   1000   1000    2005    1
 1000   1000   1000   1000   1000    2006    1
 1000   1000   1000   1000   1000    2007    1
 1000   1000   1000   1000   1000    2008    1
 1000   1000   1000   1000   1000    2009    1
 1000   1000   1000   1000   1000    2010    1
 1000   1000   1000   1000   1000    2011    1
 1000   1000   1000   1000   1000    2012    1
10 #_N_cpue
 #_Fleet Units Errtype
       1     1       0
       2     1       0
       3     1       0
       4     1       0
       5     1       0
 #_year seas index  obs se_log
   2001    1     1 10.0    0.1
   2002    1     1  9.0    0.1
   2003    1     1  8.0    0.1
   2004    1     1  7.0    0.1
   2005    1     1  6.0    0.1
   2006    1     1  5.0    0.1
   2007    1     1  5.0    0.1
   2008    1     1  4.0    0.1
   2009    1     1  4.0    0.1
   2010    1     1  3.5    0.1
0 #_N_discard_fleets
#_discard_units (1=same_as_catchunits(bio/num); 2=fraction; 3=numbers)
#_discard_errtype:  >0 for DF of T-dist(read CV below); 0 for normal with CV; -1 for normal with se; -2 for lognormal
0 #_N_discard
0 #_N_meanbodywt
30 #_DF_for_meanbodywt_T-distribution_like
2 # length bin method: 1=use databins; 2=generate from binwidth,min,max below; 3=read vector
2 # binwidth for population size comp
10 # minimum size in the population (lower edge of first bin and size at age 0.00)
98 # maximum size in the population (lower edge of last bin)
-1 #_comp_tail_compression
0.001 #_add_to_comp
1 #_combine males into females at or below this bin number
33 #_N_lbins
#_lbin_vector
26 28 30 32 34 36 38 40 42 44 46 48 50 52 54 56 58 60 62 64 66 68 70 72 74 76 78 80 82 84 86 88 90
5 #_N_Length_comp_observations
 #_Yr Seas FltSvy Gender Part Nsamp f26 f28 f30 f32 f34 f36 f38 f40 f42 f44 f46 f48 f50 f52 f54 f56 f58 f60 f62 f64 f66 f68 f70 f72 f74 f76 f78 f80 f82 f84 f86 f88 f90 m26 m28 m30 m32 m34 m36 m38 m40 m42 m44 m46 m48 m50 m52 m54 m56 m58 m60 m62 m64 m66 m68 m70 m72 m74 m76 m78 m80 m82 m84 m86 m88 m90
 2010    1      1      3    0   500   0   1   2   4  15  23  27  28  22  20  18  16  14  10  11   6   6  10   8   4   7   3   2   2   2   1   1   0   0   0   0   0   1   1   0   3   9  13  21  20  21  10  31  21  16  15  11   3   7   6   4   8   2   2   1   2   1   2   0   1   0   0   2   0   0   3
 2010    1      2      3    0   500   0   1   2   4  15  23  27  28  22  20  18  16  14  10  11   6   6  10   8   4   7   3   2   2   2   1   1   0   0   0   0   0   1   1   0   3   9  13  21  20  21  10  31  21  16  15  11   3   7   6   4   8   2   2   1   2   1   2   0   1   0   0   2   0   0   3
 2010    1      3      3    0   500   0   1   2   4  15  23  27  28  22  20  18  16  14  10  11   6   6  10   8   4   7   3   2   2   2   1   1   0   0   0   0   0   1   1   0   3   9  13  21  20  21  10  31  21  16  15  11   3   7   6   4   8   2   2   1   2   1   2   0   1   0   0   2   0   0   3
 2010    1      4      3    0   500   0   1   2   4  15  23  27  28  22  20  18  16  14  10  11   6   6  10   8   4   7   3   2   2   2   1   1   0   0   0   0   0   1   1   0   3   9  13  21  20  21  10  31  21  16  15  11   3   7   6   4   8   2   2   1   2   1   2   0   1   0   0   2   0   0   3
 2010    1      5      3    0   500   0   1   2   4  15  23  27  28  22  20  18  16  14  10  11   6   6  10   8   4   7   3   2   2   2   1   1   0   0   0   0   0   1   1   0   3   9  13  21  20  21  10  31  21  16  15  11   3   7   6   4   8   2   2   1   2   1   2   0   1   0   0   2   0   0   3
15 #_N_agebins
#_agebin_vector
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15
1 #_N_ageerror_definitions
 #_age0 age1 age2 age3 age4 age5 age6 age7 age8 age9 age10 age11 age12 age13 age14 age15 age16 age17 age18 age19 age20
   0.50 1.50 2.50 3.50 4.50 5.50 6.50 7.50 8.50 9.50 10.50 11.50 12.50 13.50 14.50 15.50 16.50 17.50 18.50 19.50 20.50
   0.01 0.01 0.01 0.01 0.01 0.01 0.01 0.01 0.01 0.01  0.01  0.01  0.01  0.01  0.01  0.01  0.01  0.01  0.01  0.01  0.01
21 #_N_agecomp
3 #_Lbin_method: 1=poplenbins; 2=datalenbins; 3=lengths
0 #_combine males into females at or below this bin number
 #_Yr Seas FltSvy Gender Part Ageerr Lbin_lo Lbin_hi Nsamp f1 f2 f3 f4 f5 f6 f7 f8 f9 f10 f11 f12 f13 f14 f15 m1 m2 m3 m4 m5 m6 m7 m8 m9 m10 m11 m12 m13 m14 m15
 2010    1     -1      3    0      1      -1      -1   250 49  0  0  0  0  0  0  0  0   0   0   0   0   0   0  0  1  0  0  0  0  0  0  0   0   0   0   0   0   0
 2010    1     -2      3    0      1      -1      -1   250 49  0  0  0  0  0  0  0  0   0   0   0   0   0   0  0  1  0  0  0  0  0  0  0   0   0   0   0   0   0
 2010    1     -3      3    0      1      -1      -1   250 49  0  0  0  0  0  0  0  0   0   0   0   0   0   0  0  1  0  0  0  0  0  0  0   0   0   0   0   0   0
 2010    1     -4      3    0      1      -1      -1   250 49  0  0  0  0  0  0  0  0   0   0   0   0   0   0  0  1  0  0  0  0  0  0  0   0   0   0   0   0   0
 2010    1     -5      3    0      1      -1      -1   250 49  0  0  0  0  0  0  0  0   0   0   0   0   0   0  0  1  0  0  0  0  0  0  0   0   0   0   0   0   0
 2010    1      4      3    0      1      26      30    50 49  0  0  0  0  0  0  0  0   0   0   0   0   0   0  0  1  0  0  0  0  0  0  0   0   0   0   0   0   0
 2010    1      4      3    0      1      30      34    50 37  2  0  0  0  0  0  0  0   0   0   0   0   0   0  0  7  2  0  0  0  2  0  0   0   0   0   0   0   0
 2010    1      4      3    0      1      34      38    50 36  2  0  0  1  0  0  0  0   0   0   0   0   0   0  0  9  0  1  1  0  0  0  0   0   0   0   0   0   0
 2010    1      4      3    0      1      38      42    50 23  6  2  0  0  0  0  0  0   0   0   0   0   0   0  0 12  6  1  0  0  0  0  0   0   0   0   0   0   0
 2010    1      4      3    0      1      42      46    50 10 13  1  0  0  0  0  0  0   0   0   0   0   0   0  0 11  9  4  0  0  0  0  1   1   0   0   0   0   0
 2010    1      4      3    0      1      46      50    50  0 10  9  1  3  0  0  0  0   0   0   0   0   0   0  0  6 11  7  2  1  0  0  0   0   0   0   0   0   0
 2010    1      4      3    0      1      50      54    50  1  3 14  2  1  1  0  0  0   0   0   0   0   1   0  0  3  9  4  7  1  1  1  0   0   0   0   0   0   1
 2010    1      4      3    0      1      54      58    50  0  1 15  8  3  0  1  1  0   0   0   0   0   0   0  0  0  2  7  4  4  1  1  1   0   0   1   0   0   0
 2010    1      4      3    0      1      58      62    50  0  1  2  6  6  6  1  1  0   0   0   0   0   0   0  0  0  1  5  4  7  1  4  0   2   0   1   1   0   1
 2010    1      4      3    0      1      62      66    50  0  0  2 10  5  6  4  1  1   1   0   0   0   0   0  0  0  0  0  2  2  4  3  4   3   1   0   0   0   1
 2010    1      4      3    0      1      66      70    50  0  0  0  2  4 11  2  2  4   1   0   2   1   0   2  0  0  0  1  2  0  4  1  1   3   2   1   1   0   3
 2010    1      4      3    0      1      70      74    50  0  0  1  0  3  4  5  5  2   6   1   0   4   2   2  0  0  0  0  1  0  0  0  1   3   2   2   1   1   4
 2010    1      4      3    0      1      74      78    50  0  0  0  0  1  3  9  6  5   0   4   1   4   1   6  0  0  0  0  0  0  0  2  0   0   1   1   3   0   3
 2010    1      4      3    0      1      78      82    50  0  0  0  0  0  0  5  8  3   4   2   3   1   4  12  0  0  1  0  0  1  0  0  2   0   0   2   0   1   1
 2010    1      4      3    0      1      82      86    50  0  0  0  0  0  1  0  4  3   2   8   3   4   3  15  0  0  0  0  0  0  0  0  1   0   0   0   2   1   3
 2010    1      4      3    0      1      86      90    50  0  0  0  0  0  0  0  2  1   3   7   4   6   3  24  0  0  0  0  0  0  0  0  0   0   0   0   0   0   0
0 #_N_MeanSize_at_Age_obs
0 #_N_environ_variables
0 #_N_environ_obs
0 #_N_sizefreq_methods
0 #_do_tags
0 #_morphcomp_data
#
999
