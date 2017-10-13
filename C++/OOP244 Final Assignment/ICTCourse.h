#include "Course.h"
#include "general.h"

namespace sict{
	class ICTCourse:public Course{
		char computerSystem_[6 + 1];
	public: ICTCourse(const char* code, const char* title, int credits, int study, const char* system);
			ICTCourse(const char* code, const char* title, int credits, int study);
			ICTCourse();
			const char* getComputerSystem() const;
			void setComputerSystem(const char* value);
			void display(ostream& pout);//derived from base class
			fstream& ICTCourse::store(fstream& fileStream, bool addNewLine) const; //derived from Streamable class
			ostream& ICTCourse::display(ostream& os) const; //derived display function from Streamable
			istream& ICTCourse::read(istream& istr); //derived istream function from Streamable
			fstream& ICTCourse::load(fstream& fileStream); //derived load function from Streamable
	};
	std::ostream& operator<<(std::ostream& pout, ICTCourse& a);
}